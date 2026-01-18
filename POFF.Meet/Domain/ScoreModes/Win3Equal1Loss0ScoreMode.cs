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

            WinDrawLoss sets = new();
            ScoredConceded goals = new();

            foreach (var setResult in match.Result.SetResults)
            {
                var x = setResult.Home.CompareTo(setResult.Guest);
                sets += new WinDrawLoss(x > 0 ? 1 : 0, x == 0 ? 1 : 0, x < 0 ? 1 : 0);
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
            standing1.Score += points.Scored;
            standing1.Matches += sets;
            standing1.Frames += goals;

            var standing2 = list[match.Team2];
            standing2.MatchCount += 1;
            standing2.Score += points.Conceded;
            standing2.Matches += new WinDrawLoss(sets.Losses, sets.Draws, sets.Wins);
            standing2.Frames += new ScoredConceded(goals.Conceded, goals.Scored);
        }

        // Set place numbers 
        var ranking = list.Values
            .OrderByDescending(l => l.Score)
            .ThenByDescending(l => l.MatchCount)
            .ThenByDescending(l => l.Matches.Difference)
            .ThenByDescending(l => l.Frames.Difference);

        int place = 0;
        foreach (var standing in ranking)
        {
            standing.Place = ++place;
        }

        return ranking;
    }
}