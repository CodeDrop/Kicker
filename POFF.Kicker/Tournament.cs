using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POFF.Kicker.Model;

public class Tournament
{

    public Tournament()
    {
        TeamManager = new TeamManager();
        MatchManager = new MatchManager();
        StandingManager = new StandingManager();
    }

    private readonly StandingManager StandingManager;

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

    public void Save()
    {
        Database.Save(typeof(Team[]), TeamManager.GetTeams());
        MatchManager.Save();
    }

    public IEnumerable<Standing> GetStandings()
    {
        return StandingManager.GetStandings(MatchManager.GetMatches(MatchStatus.Finished));
    }

    public void CopyStandingsHtmlToClipboard()
    {
        var export = new HtmlExport(this);
        Clipboard.SetText(export.ToString());
    }

    private bool ContainsWithdrawnTeam(Match match)
    {
        var team1 = GetTeams.Single(t => t.Equals(match.Team1));
        var team2 = GetTeams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }

}