using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using System.Collections.Generic;
using System.Linq;

namespace POFF.Meet;

public class SwissSystemPlayMode : PlayMode
{
    public SwissSystemPlayMode() : base("Swiss System")
    { }

    public override bool IsIterative => true;

    public override IEnumerable<Fixture> Generate(int teamsCount)
    {
        if (teamsCount % 2 != 0) yield break;

        for (int i = 1; i < teamsCount; i += 2)
        {
            yield return new Fixture(i - 1, i) { Section = 1 };
        }
    }

    public override IEnumerable<Fixture> Generate(int teamsCount, IEnumerable<Match> playedMatches = null)
    {
        if (teamsCount % 2 != 0 || !playedMatches.Any()) yield break;
        // This is a placeholder implementation for Swiss System pairing.
        // A real implementation would consider the results of playedMatches.
        for (int i = 1; i < teamsCount; i += 2)
        {
            yield return new Fixture(i - 1, i) { Section = 1 };
        }
    }
}