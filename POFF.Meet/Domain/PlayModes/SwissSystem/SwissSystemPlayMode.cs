using POFF.Meet.Domain.PlayModes;
using System.Collections.Generic;

namespace POFF.Meet;

public class SwissSystemPlayMode : PlayMode
{
    public SwissSystemPlayMode() : base("Swiss System")
    { }

    public override IEnumerable<Fixture> Generate(int teamsCount)
    {
        if (teamsCount % 2 != 0) yield break;

        for (int i = 1; i < teamsCount; i += 2)
        {
            yield return new Fixture(i - 1, i) { Section = 1 };
        }
    }
}