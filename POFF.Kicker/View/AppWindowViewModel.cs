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
    private readonly ITournamentStorage _storage = new FileTournamentStorage();

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

    public Tournament Tournament { get; }

    private int TabIndexValue;
    public int TabIndex
    {
        get
        {
            return TabIndexValue;
        }
        set
        {
            if (value == TabIndexValue)
                return;
            TabIndexValue = value;
            OnPropertyChanged();
        }
    }

    public TeamsScreenViewModel TeamsScreen { get; }

    public void AddTeam(TeamInfo team)
    {
        TeamsScreen.AddTeam(team.Team);
    }

    public void RemoveTeam(Team team)
    {
        TeamsScreen.RemoveTeam(team);
    }

    public void Save()
    {
        Tournament.Save();
    }

    public void CopyToClipboard()
    {
        Tournament.CopyStandingsHtmlToClipboard();
    }
}