using POFF.Meet.Domain.PlayModes;
using System.Collections.Generic;

namespace POFF.Meet;

public class SwissSystemPlayMode : PlayMode
{
    public SwissSystemPlayMode() : base("Swiss System")
    { }

    public override IEnumerable<Fixture> Generate(int teamsCount)
    {
        return [];
    }
}