using System;
using System.ComponentModel;
using POFF.Kicker.Domain;
using POFF.Kicker.View.Model;
using POFF.Kicker.Types;
using POFF.Kicker.Infrastructure;

namespace POFF.Kicker.View;

public class AppWindowViewModel : ViewModelBase
{
    public static AppWindowViewModel Instance = new();
    private ITournamentStorage _storage = new FileTournamentStorage();

    private AppWindowViewModel()
    {
        Tournament = _storage.Load();
        TeamsScreen = new TeamsScreenViewModel(Tournament);
    }

    public static T DI<T>() where T : ViewModelBase
    {
        if (ReferenceEquals(typeof(T), typeof(TeamsScreenViewModel)))
        {
            return (T)(ViewModelBase)Instance.TeamsScreen;
        }

        throw new ArgumentOutOfRangeException("type", "Unexpected type");
    }

    public BindingList<Team> Teams
    {
        get
        {
            return TeamsScreen.Teams;
        }
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

    public void AddTeam(TeamInfo team)
    {
        TeamsScreen.AddTeam(team.Team);
    }

    public void Open(string filename)
    {
        _storage = new FileTournamentStorage(filename);
        Tournament = _storage.Load();
        TeamsScreen = new TeamsScreenViewModel(Tournament);
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