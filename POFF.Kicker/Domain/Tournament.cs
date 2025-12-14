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
    private readonly List<Team> _teams = new();
    private readonly List<Match> _matches = new();

    public Tournament() : this([], [])
    { }

    public Tournament(IEnumerable<Team> teams, Match[] matches)
    {
        _teams.AddRange(teams);
        _matches.AddRange(matches);
        MatchManager = new MatchManager();
        _standingManager = new StandingManager();
    }

    public IEnumerable<Team> Teams => _teams;

    public IEnumerable<Match> Matches => _matches;

    public IEnumerable<Match> FinishedMatches()
    {
        return _matches.Where(m => m.Status == MatchStatus.Finished);
    }

    public MatchManager MatchManager { get; private set; }

    public void Start(TournamentType @type)
    {
        _matches.Clear();
        _matches.AddRange(MatchManager.Generate(_teams.ToArray()));
    }

    public int TotalMatchCount()
    {
        return _matches.Count(m => !ContainsWithdrawnTeam(m));
    }

    public int PlayedMatchCount()
    {
        return FinishedMatches().Count();
    }

    public void AddTeam(Team team)
    {
        _teams.Add(team);
    }

    public void RemoveTeam(Team team)
    {
        if (team is null)
            throw new ArgumentNullException("team");

        _teams.Remove(team);
        _matches.Clear();
    }

    public IEnumerable<Standing> GetStandings()
    {
        return _standingManager.GetStandings([.. FinishedMatches()]);
    }

    public void CopyToClipboard(ExportType exportType)
    {
        var export = new HtmlExport(this, exportType);
        Clipboard.SetText(export.ToString());
    }

    private bool ContainsWithdrawnTeam(Match match)
    {
        if (!_teams.Any()) return false;
        var team1 = _teams.Single(t => t.Equals(match.Team1));
        var team2 = _teams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }
}