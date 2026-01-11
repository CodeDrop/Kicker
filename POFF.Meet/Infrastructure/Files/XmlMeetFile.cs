using POFF.Meet.Domain;
using System;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure.Files;

[Serializable]
[XmlRoot("TournamentFile")]
public class XmlMeetFile
{
    public Guid Id { get; set; } 
    public Team[] Teams { get; set; } = [];
    public Match[] Matches { get; set; } = [];
    public string PlayMode { get; set; }
}
