using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;
using System.ComponentModel;

namespace POFF.Kicker.View;

public class AppWindowViewModel : ViewModelBase
{
    public static AppWindowViewModel Instance = new();
    private ITournamentStorage _storage = new FileTournamentStorage();

    private AppWindowViewModel()
    {
        TeamsScreen = new TeamsScreenViewModel();
        OpenTournament();
    }

    private void OpenTournament()
    {
        Tournament = _storage.Load();
        Teams.Clear();
        foreach (Team team in Tournament.Teams)
            Teams.Add(team);
    }

    public Tournament Tournament { get; private set; }

    private int _tabIndexValue;
    public int TabIndex
    {
        get
        {
            return _tabIndexValue;
        }
        set
        {
            if (value == _tabIndexValue)
                return;
            _tabIndexValue = value;
            OnPropertyChanged();
        }
    }

    public BindingList<Team> Teams { get; } = [];

    public TeamsScreenViewModel TeamsScreen { get; private set; }

    public Team SelectedTeam => TeamsScreen.SelectedTeam?.Team;

    public void AddTeam(TeamInfo teamInfo)
    {
        Tournament.AddTeam(teamInfo.Team);
        Teams.Add(teamInfo.Team);
    }

    public void RemoveTeam()
    {
        if (SelectedTeam is not null)
        {
            Tournament.RemoveTeam(SelectedTeam);
            Teams.Remove(SelectedTeam);
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