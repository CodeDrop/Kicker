using System.Collections.Generic;

namespace POFF.Meet.Domain.PlayModes;

public interface IPlayMode
{
    string Name { get; }
    IEnumerable<Fixture> Generate(int teamsCount);
}