using POFF.Meet.Domain;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure.Files
{
    [XmlRoot("Meet")]
    public class MeetFile2
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlArray("Teams")]
        [XmlArrayItem("Team")]
        public List<TeamEntry> Teams { get; set; }

        [XmlArray("Matches")]
        [XmlArrayItem("Match")]
        public List<MatchEntry> Matches { get; set; }

        [XmlArray("Results")]
        [XmlArrayItem("Result")]
        public List<ResultEntry> Results { get; set; }
    }

    public class TeamEntry
    {
        [XmlAttribute("No")]
        public int No { get; set; }

        [XmlText]
        public string Name { get; set; }
    }

    public class MatchEntry
    {
        [XmlAttribute("No")]
        public int No { get; set; }

        [XmlAttribute("Round")]
        public int Round { get; set; }

        [XmlAttribute("HomeNo")]
        public int HomeNo { get; set; }

        [XmlAttribute("GuestNo")]
        public int GuestNo { get; set; }

        [XmlText]
        public MatchStatus Status { get; set; }
    }

    public class ResultEntry
    {
        [XmlAttribute("HomeNo")]
        public int HomeNo { get; set; }

        [XmlAttribute("GuestNo")]
        public int GuestNo { get; set; }

        [XmlArray("Sets")]
        [XmlArrayItem("Set")]
        public List<SetEntry> Sets { get; set; }
    }

    public class SetEntry
    {
        [XmlAttribute("Home")]
        public int Home { get; set; }

        [XmlAttribute("Guest")]
        public int Guest { get; set; }
    }
}
