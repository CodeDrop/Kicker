using POFF.Kicker.Domain;
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
    }

    public Tournament Tournament { get; private set; }

    public BindingList<Team> Teams { get; } = [];

    public BindingList<Match> Matches { get; } = [];

    public Team SelectedTeam { get; set; }
    
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
    }

    public void RemoveTeam()
    {
        if (SelectedTeam is not null)
        {
            Tournament.RemoveTeam(SelectedTeam);
            Teams.Remove(SelectedTeam);
            Matches.SetValues(Tournament.Matches);
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
}