using System.Collections.Generic;

namespace POFF.Meet.Domain.PlayModes;

public interface IPlayMode
{
    IEnumerable<Fixture> Generate(int teamsCount);
}