using System.Collections.Generic;

namespace POFF.Meet.Domain.PlayModes;

public abstract class PlayMode(in string name)
{
    public static readonly PlayMode Empty = new PlayModeEmpty();

    public string Name { get; } = name;

    public abstract IEnumerable<Fixture> Generate(int teamsCount);

    public override bool Equals(object obj)
    {
        return obj is PlayMode otherPlayMode && otherPlayMode.GetType().Name == GetType().Name;
    }
    override public int GetHashCode()
    {
        return GetType().Name.GetHashCode();
    }
}

public class PlayModeEmpty : PlayMode
{
    public PlayModeEmpty() : base(string.Empty)
    { }

    public override IEnumerable<Fixture> Generate(int teamsCount) => [];
}