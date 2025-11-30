using POFF.Kicker.Infrastructure;
using POFF.Kicker.Domain.MatchGenerators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Kicker.Domain;

public class MatchManager
{
    public MatchManager()
    {
        Load();
    }

    private Match[] _matches = [];

    public void Clear()
    {
        _matches = [];
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
        _matches = new Match[(matchIndexes.Count())]; // Reset
        int matchNumber = 1;

        foreach (var matchIndexPair in matchIndexes)
        {
            _matches[matchNumber - 1] = new Match(matchNumber, teams[matchIndexPair.Item1], teams[matchIndexPair.Item2]);
            matchNumber += 1;
        }
    }

    // Get next match with fitting status
    public Match GetNextMatch()
    {
        bool teamConflict;

        foreach (var match in _matches)
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
        return _matches;
    }

    // Get matches depending on running status
    public Match[] GetMatches(MatchStatus matchStatus)
    {
        var matchesInStatus = new List<Match>();

        for (int index = 0, loopTo = _matches.Length - 1; index <= loopTo; index++)
        {
            if (_matches[index].Status == matchStatus)
            {
                matchesInStatus.Add(_matches[index]);
            }
        }

        return [.. matchesInStatus];
    }

    public void SetStatus(int matchNo, Result result)
    {
        SetStatus(matchNo, MatchStatus.Finished);
        _matches[matchNo - 1].Result = result;
    }

    private void SetStatus(int matchNo, MatchStatus matchStatus)
    {
        if (matchNo < 1 | matchNo > _matches.Length)
            throw new IndexOutOfRangeException("matchNo may only have values between 1 and number of matches");
        _matches[matchNo - 1].Status = matchStatus;
    }

    private void Load()
    {
        var data = Database.Load(typeof(Match[]));
        if (data is not null)
            _matches = (Match[])data;
    }

    public void Save()
    {
        Database.Save(typeof(Match[]), _matches);
    }
}