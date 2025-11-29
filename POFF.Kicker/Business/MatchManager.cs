using System;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Kicker.Model;

public class MatchManager
{

    public MatchManager()
    {
        Load();
    }

    private Match[] Matches = [];

    public void Clear()
    {
        Matches = new Match[0];
    }

    public void Generate(Team[] teams, TournamentType @type = TournamentType.Standard)
    {
        if (teams is null)
            return;

        IMatchGenerator matchGenerator;
        if (type == TournamentType.MatchDays)
        {
            matchGenerator = new MatchdaysMatchGenerator(teams.Count());
        }
        else
        {
            matchGenerator = new GeneticMatchGenerator(teams.Count());
        }

        var matchIndexes = matchGenerator.Generate();
        Matches = new Match[(matchIndexes.Count())]; // Reset
        int matchNumber = 1;

        foreach (var matchIndexPair in matchIndexes)
        {
            Matches[matchNumber - 1] = new Match(matchNumber, teams[matchIndexPair.Item1], teams[matchIndexPair.Item2]);
            matchNumber += 1;
        }
    }

    // Get next match with fitting status
    public Match GetNextMatch()
    {
        bool teamConflict;

        foreach (var match in Matches)
        {
            if (match.Status == MatchStatus.Open)
            {
                teamConflict = false;

                foreach (var runningMatch in GetMatches(MatchStatus.Running))
                {
                    teamConflict = runningMatch.HasTeam(match.Team1) | runningMatch.HasTeam(match.Team2);
                    if (teamConflict)
                        break;
                }

                if (!teamConflict)
                    return match;
            }
        }

        return null;
    }

    // Get all matches
    public Match[] GetMatches()
    {
        return Matches;
    }

    // Get matches depending on running status
    public Match[] GetMatches(MatchStatus matchStatus)
    {
        var matchesInStatus = new List<Match>();

        for (int index = 0, loopTo = Matches.Length - 1; index <= loopTo; index++)
        {
            if (Matches[index].Status == matchStatus)
            {
                matchesInStatus.Add(Matches[index]);
            }
        }

        return matchesInStatus.ToArray();
    }

    public void SetStatus(int matchNo, Result result)
    {
        SetStatus(matchNo, MatchStatus.Finished);
        Matches[matchNo - 1].Result = result;
    }

    private void SetStatus(int matchNo, MatchStatus matchStatus)
    {
        if (matchNo < 1 | matchNo > Matches.Length)
            throw new IndexOutOfRangeException("matchNo may only have values between 1 and number of matches");
        Matches[matchNo - 1].Status = matchStatus;
    }

    private void Load()
    {
        var data = Database.Load(typeof(Match[]));
        if (data is not null)
            Matches = (Match[])data;
    }

    public void Save()
    {
        Database.Save(typeof(Match[]), Matches);
    }

}