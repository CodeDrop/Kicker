using POFF.Kicker.Domain;
using System;

namespace POFF.Kicker.Infrastructure
{
    [Serializable]
    public class TournamentFile
    {
        public Team[] Teams { get; set; } = [];
        public Match[] Matches { get; set; } = [];
    }
}
