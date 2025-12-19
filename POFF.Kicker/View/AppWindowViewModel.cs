using POFF.Kicker.Domain;
using POFF.Kicker.Domain.ScoreModes;
using POFF.Kicker.Extensions;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;
using System.ComponentModel;
using System.Linq;

namespace POFF.Kicker.View;

public class AppWindowViewModel : ViewModelBase
{
    public static AppWindowViewModel Instance = new();
    private ITournamentStorage _storage = new FileTournamentStorage();

    private AppWindowViewModel()
    {
        OpenTournament();
    }

    private void OpenTournament()
    {
        Tournament = _storage.Load();
        Teams.SetValues(Tournament.Teams);
        Matches.SetValues(Tournament.Matches);
        Standings.SetValues(Tournament.GetStandings());
    }

    public Tournament Tournament { get; private set; }

    public BindingList<Team> Teams { get; } = [];

    public BindingList<Match> Matches { get; } = [];

    public BindingList<Standing> Standings { get; } = [];

    public Team SelectedTeam { get; set; }

    public Match SelectedMatch { get; set; }

    public string MatchFilter 
    {
        set
        {
            var matches= Tournament.Matches.Where(m=> string.IsNullOrEmpty(value) ||
                m.Team1.Name == value ||
                m.Team2.Name == value);
            Matches.SetValues(matches);
        }
    }

    public void AddTeam(TeamInfo teamInfo)
    {
        Tournament.AddTeam(teamInfo.Team);
        Teams.Add(teamInfo.Team);
        Matches.SetValues(Tournament.Matches);
        Standings.SetValues(Tournament.GetStandings());
    }

    public void RemoveTeam()
    {
        if (SelectedTeam is not null)
        {
            Tournament.RemoveTeam(SelectedTeam);
            Teams.Remove(SelectedTeam);
            Matches.SetValues(Tournament.Matches);
            Standings.SetValues(Tournament.GetStandings());
        }
    }

    public void Open(string filename)
    {
        _storage = new FileTournamentStorage(filename);
        OpenTournament();
    }

    public void Save()
    {
        _storage.Save(Tournament);
    }

    public void CopyToClipboard(ExportType exportType)
    {
        Tournament.CopyToClipboard(exportType);
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
        Standings.SetValues(Tournament.GetStandings());
    }
}