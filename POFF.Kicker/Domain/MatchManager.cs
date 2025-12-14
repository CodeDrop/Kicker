using POFF.Kicker.Domain.MatchGenerators;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Kicker.Domain;

public class MatchManager
{
    public IEnumerable<Match> Generate(Team[] teams, TournamentType @type = TournamentType.Standard)
    {
        if (teams is null) return [];
        Match[] _matches = [];

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
}