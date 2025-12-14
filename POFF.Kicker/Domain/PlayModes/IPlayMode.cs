using System.Collections.Generic;

namespace POFF.Kicker.Domain.PlayModes;

public interface IPlayMode
{
    IEnumerable<Fixture> Generate(int teamsCount);
}