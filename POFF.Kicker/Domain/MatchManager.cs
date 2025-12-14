using POFF.Kicker.Domain.MatchGenerators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Kicker.Domain;

public class MatchManager
{
    private Match[] _matches = [];

    public IEnumerable<Match> Generate(Team[] teams, TournamentType @type = TournamentType.Standard)
    {
        if (teams is null) return [];

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

        return _matches;
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
}