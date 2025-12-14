using POFF.Kicker.Domain;
using POFF.Kicker.Domain.MatchGenerators;
using POFF.Kicker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POFF.Kicker.View.Model;

public class Tournament
{
    private readonly List<Team> _teams = [];
    private readonly List<Match> _matches = [];
    private readonly StandingManager _standingManager;

    public Tournament() : this([], [])
    { }

    public Tournament(IEnumerable<Team> teams, Match[] matches)
    {
        _teams.AddRange(teams);
        _matches.AddRange(matches);
        _standingManager = new StandingManager();
    }

    public IEnumerable<Team> Teams => _teams;

    public IEnumerable<Match> Matches => _matches;

    public void Start(TournamentType tournamentType = TournamentType.Standard)
    {
        _matches.Clear();

        IMatchGenerator matchGenerator =
            tournamentType == TournamentType.MatchDays ?
            new MatchdaysMatchGenerator(_teams.Count()) : new GeneticMatchGenerator(_teams.Count());

        var matchIndexes = matchGenerator.Generate();

        foreach (var matchIndexPair in matchIndexes)
        {
            _matches.Add(new Match(_matches.Count + 1, _teams[matchIndexPair.Item1], _teams[matchIndexPair.Item2]));
        }
    }

    public void SetResult(int matchNo, Result result)
    {
        if (matchNo < 1 | matchNo > _matches.Count)
            throw new IndexOutOfRangeException("matchNo may only have values between 1 and number of matches");

        _matches[matchNo - 1].Result = result;
        _matches[matchNo - 1].Status = MatchStatus.Finished;
    }

    public IEnumerable<Match> FinishedMatches()
    {
        return _matches.Where(m => m.Status == MatchStatus.Finished);
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