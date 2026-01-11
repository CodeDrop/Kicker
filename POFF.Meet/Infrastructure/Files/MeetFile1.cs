using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure.Files;

[Serializable]
[XmlRoot("TournamentFile")]
public class MeetFile1 : MeetFileBase
{
    public Guid Id { get; set; }
    public Team[] Teams { get; set; } = [];
    public Match[] Matches { get; set; } = [];
    public string PlayMode { get; set; }

    public override Tournament ToTournament()
    {
        var id = (Id != Guid.Empty) ? Id : Guid.NewGuid();
        var teams = Teams.ToList();
        var matches = Matches.ToList();
        PlayMode playMode = GetPlayMode(PlayMode);

        if (teams.Any(t => t.Number == 0))
        {
            FixTeamNumbers(teams, matches);
        }
        foreach (var match in matches)
        {
            match.Team1 = teams.Single(t => t.Number == match.Team1.Number);
            match.Team2 = teams.Single(t => t.Number == match.Team2.Number);
        }

        return new Tournament(id, teams, matches, playMode);
    }

    private void FixTeamNumbers(List<Team> teams, List<Match> matches)
    {
        for (int i = 0; i < teams.Count; i++)
        {
            teams[i].Number = i + 1;
        }
        foreach (var match in matches)
        {
            match.Team1 = teams.Single(t => t.Name == match.Team1.Name);
            match.Team2 = teams.Single(t => t.Name == match.Team2.Name);
        }
    }
}
