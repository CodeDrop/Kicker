using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POFF.Kicker.View.Model;

public class Tournament
{
    private readonly StandingManager _standingManager;

    public Tournament() : this([], [])
    { }

    public Tournament(Team[] teams, Match[] matches)
    {
        TeamManager = new TeamManager(teams);
        MatchManager = new MatchManager(matches);
        _standingManager = new StandingManager();
    }

    public TeamManager TeamManager { get; private set; }

    public MatchManager MatchManager { get; private set; }

    public void Start(TournamentType @type)
    {
        MatchManager.Generate(GetTeams, type);
    }

    public int TotalMatchCount()
    {
        return MatchManager.GetMatches().Count(m => !ContainsWithdrawnTeam(m));
    }

    public int PlayedMatchCount()
    {
        return MatchManager.GetMatches(MatchStatus.Finished).Length;
    }

    public Team[] GetTeams
    {
        get
        {
            return TeamManager.GetTeams();
        }
    }

    public void AddTeam(Team team)
    {
        TeamManager.AddTeam(team);
        MatchManager.Clear();
    }

    public void RemoveTeam(Team team)
    {
        if (team is null)
            throw new ArgumentNullException("team");

        TeamManager.RemoveTeam(team);
        MatchManager.Clear();
    }

    public IEnumerable<Standing> GetStandings()
    {
        return _standingManager.GetStandings(MatchManager.GetMatches(MatchStatus.Finished));
    }

    public void CopyToClipboard(ExportType exportType)
    {
        var export = new HtmlExport(this, exportType);
        Clipboard.SetText(export.ToString());
    }

    private bool ContainsWithdrawnTeam(Match match)
    {
        if (!GetTeams.Any()) return false;
        var team1 = GetTeams.Single(t => t.Equals(match.Team1));
        var team2 = GetTeams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }
}