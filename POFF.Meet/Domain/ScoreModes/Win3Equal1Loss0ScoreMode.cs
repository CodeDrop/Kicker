using System;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Meet.Domain.ScoreModes;

public class Win3Equal1Loss0ScoreMode : IScoreMode
{
    public IEnumerable<Standing> Evaluate(IEnumerable<Match> matches)
    {
        var list = new Dictionary<Team, Standing>();
        foreach (var match in matches)
        {
            if (match.Team1.Withdrawn || match.Team2.Withdrawn) continue;

            if (!list.ContainsKey(match.Team1))
                list.Add(match.Team1, new Standing(match.Team1));
            if (!list.ContainsKey(match.Team2))
                list.Add(match.Team2, new Standing(match.Team2));

            if (match.Status != MatchStatus.Finished) continue;

            ScoredConceded sets = new();
            ScoredConceded goals = new();

            foreach (var setResult in match.Result.SetResults)
            {
                var x = setResult.Home.CompareTo(setResult.Guest);
                sets += new ScoredConceded(x > 0 ? 1 : 0, x < 0 ? 1 : 0);
                goals += new ScoredConceded(setResult.Home, setResult.Guest);
            }

            var points = sets.Difference switch
            {
                > 0 => new ScoredConceded(3, 0),
                0 => new ScoredConceded(1, 1),
                < 0 => new ScoredConceded(0, 3),
            };

            var standing1 = list[match.Team1];
            standing1.MatchCount += 1;
            standing1.Points += points.Scored;
            standing1.Sets += sets;
            standing1.Goals += goals;

            var standing2 = list[match.Team2];
            standing2.MatchCount += 1;
            standing2.Points += points.Conceded;
            standing2.Sets += new ScoredConceded(sets.Conceded, sets.Scored);
            standing2.Goals += new ScoredConceded(goals.Conceded, goals.Scored);
        }

        // Set place numbers 
        int place = 0;
        foreach (var standing in list.OrderBy(l => l.Value))
        {
            standing.Value.Place = ++place;
        }

        return list.Values.OrderBy(l => l);
    }
}