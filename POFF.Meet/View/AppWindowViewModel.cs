using POFF.Meet.Domain;
using POFF.Meet.Domain.ScoreModes;
using POFF.Meet.Extensions;
using POFF.Meet.Infrastructure;
using POFF.Meet.View.Model;
using System.ComponentModel;
using System.Linq;

namespace POFF.Meet.View;

public class AppWindowViewModel : ViewModelBase
{
    private ITournamentStorage _storage = new FileTournamentStorage();
    private Tournament _tournament = Tournament.Empty;

    public AppWindowViewModel()
    {
        SetTeamsMatchesAndStandings();
    }

    public void Open(string filename)
    {
        _storage = new FileTournamentStorage(filename);
        _tournament = _storage.Load();
        SetTeamsMatchesAndStandings();
        IsDirty = false;
    }

    public void Save()
    {
        _storage.Save(_tournament);
        IsDirty = false;
    }

    private void SetTeamsMatchesAndStandings()
    {
        Teams.SetValues(_tournament.Teams);
        Matches.SetValues(_tournament.Matches);
        Standings.SetValues(_tournament.GetStandings());
    }

    public BindingList<Team> Teams { get; } = [];

    public BindingList<Match> Matches { get; } = [];

    public BindingList<Standing> Standings { get; } = [];

    public Team SelectedTeam { get; set; }

    public Match SelectedMatch { get; set; }

    public string MatchFilter
    {
        set
        {
            var matches = _tournament.Matches.Where(m => string.IsNullOrEmpty(value) ||
                m.Team1.Name == value ||
                m.Team2.Name == value);
            Matches.SetValues(matches);
        }
    }

    public bool IsDirty { get; private set; }

    public void AddTeam(TeamInfo teamInfo)
    {
        _tournament.AddTeam(teamInfo.Team);
        Teams.Add(teamInfo.Team);
        Matches.SetValues(_tournament.Matches);
        Standings.SetValues(_tournament.GetStandings());
        IsDirty = true;
    }

    public void RemoveTeam()
    {
        if (SelectedTeam is not null)
        {
            _tournament.RemoveTeam(SelectedTeam);
            Teams.Remove(SelectedTeam);
            Matches.SetValues(_tournament.Matches);
            Standings.SetValues(_tournament.GetStandings());
        }
        IsDirty = true;
    }

    public void ProcessResult(BindingList<SetResultInput> setResults)
    {
        if (SelectedMatch is null) return;

        SelectedMatch.Result.Clear();

        foreach (SetResultInput input in setResults)
        {
            if (input.Home.HasValue && input.Guest.HasValue)
            {
                SelectedMatch.Result.AddSetResult(new SetResult { Home = input.Home.Value, Guest = input.Guest.Value });
            }
        }
        SelectedMatch.Status = SelectedMatch.Result.SetResults.Any() ? MatchStatus.Finished : MatchStatus.Open;
        Matches.ResetBindings();
        Standings.SetValues(_tournament.GetStandings());
        IsDirty = true;
    }

    public void CopyToClipboard(ExportType exportType)
    {
        _tournament.CopyToClipboard(exportType);
    }

    public int TotalMatchCount()
    {
        return Matches.Count(m => !ContainsWithdrawnTeam(m));
    }

    public int PlayedMatchCount()
    {
        return Matches.Count(m => m.Status == MatchStatus.Finished);
    }

    private bool ContainsWithdrawnTeam(Match match)
    {
        if (!Teams.Any()) return false;
        var team1 = Teams.Single(t => t.Equals(match.Team1));
        var team2 = Teams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }

}