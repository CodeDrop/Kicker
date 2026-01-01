using POFF.Meet.Domain;
using System;

namespace POFF.Meet.Infrastructure;

[Serializable]
public class TournamentFile
{
    public Guid Id { get; set; } 
    public Team[] Teams { get; set; } = [];
    public Match[] Matches { get; set; } = [];
}
