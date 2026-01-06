using System;
using System.Diagnostics;

namespace POFF.Meet.Domain;

[Serializable()]
[DebuggerDisplay("{Name}")]
public class Team
{
    public int Number { get; set; } 
    public string Name { get; set; } = "";
    public string Player1 { get; set; }
    public string Player2 { get; set; }
    public bool Withdrawn { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is not Team otherTeam) return false;
        return Number == otherTeam.Number;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
    
    public override string ToString()
    {
        return Name;
    }
}