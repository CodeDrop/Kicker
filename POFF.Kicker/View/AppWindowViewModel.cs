using POFF.Kicker.View.Model;
using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;

namespace POFF.Kicker.View;

public class AppWindowViewModel : ViewModelBase
{
    public static AppWindowViewModel Instance = new();
    private ITournamentStorage _storage = new FileTournamentStorage();

    private AppWindowViewModel()
    {
        Tournament = _storage.Load();
        TeamsScreen = new TeamsScreenViewModel();
        TeamsScreen.SetTournament(Tournament);
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

    public TeamsScreenViewModel TeamsScreen { get; private set; }

    public Team SelectedTeam => TeamsScreen.SelectedTeam?.Team;

    public void AddTeam(TeamInfo teamInfo)
    {
        Tournament.AddTeam(teamInfo.Team);
        TeamsScreen.Teams.Add(teamInfo.Team);
    }

    public void RemoveTeam()
    {
        if (SelectedTeam is Team)
        {
            Tournament.RemoveTeam(SelectedTeam);
            TeamsScreen.Teams.Remove(SelectedTeam);
        }
    }

    public void Open(string filename)
    {
        _storage = new FileTournamentStorage(filename);
        Tournament = _storage.Load();
        TeamsScreen.SetTournament(Tournament);
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