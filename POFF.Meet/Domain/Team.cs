using System;
using System.Diagnostics;

namespace POFF.Meet.Domain;

[Serializable()]
[DebuggerDisplay("{Name}")]
public class Team
{
    public string Name { get; set; } = "";
    public string Player1 { get; set; }
    public string Player2 { get; set; }
    public bool Withdrawn { get; set; }

    public override bool Equals(object obj)
    {
        Team otherTeam = (Team)obj;
        return Name.Equals(otherTeam.Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}