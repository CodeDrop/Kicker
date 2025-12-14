using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POFF.Kicker.View.Model;

public class Tournament
{
    private readonly List<Team> _teams = new();
    private readonly List<Match> _matches = new();
    private readonly MatchManager _matchManager;
    private readonly StandingManager _standingManager;

    public Tournament() : this([], [])
    { }

    public Tournament(IEnumerable<Team> teams, Match[] matches)
    {
        _teams.AddRange(teams);
        _matches.AddRange(matches);
        _matchManager = new MatchManager();
        _standingManager = new StandingManager();
    }

    public IEnumerable<Team> Teams => _teams;

    public IEnumerable<Match> Matches => _matches;

    public IEnumerable<Match> FinishedMatches()
    {
        return _matches.Where(m => m.Status == MatchStatus.Finished);
    }

    public void SetResult(int matchNo, Result result)
    {
        if (matchNo < 1 | matchNo > _matches.Count)
            throw new IndexOutOfRangeException("matchNo may only have values between 1 and number of matches");

        _matches[matchNo - 1].Result = result;
        _matches[matchNo - 1].Status = MatchStatus.Finished;
    }

    public void Start()
    {
        _matches.Clear();
        _matches.AddRange(_matchManager.Generate(_teams.ToArray()));
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