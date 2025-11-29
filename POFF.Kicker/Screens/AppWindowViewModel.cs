using System;
using System.ComponentModel;
using POFF.Kicker.Data;
using POFF.Kicker.View.Model;
using POFF.Kicker.Types;

namespace POFF.Kicker.Screens;

public class AppWindowViewModel : ViewModelBase
{

    public static AppWindowViewModel Instance = new AppWindowViewModel();

    private AppWindowViewModel()
    {
        TournamentValue = new Tournament();
        TeamsScreenValue = new TeamsScreenViewModel(TournamentValue);
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

    private Tournament TournamentValue;
    public Tournament Tournament
    {
        get
        {
            return TournamentValue;
        }
    }

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

    private readonly TeamsScreenViewModel TeamsScreenValue;
    public TeamsScreenViewModel TeamsScreen
    {
        get
        {
            return TeamsScreenValue;
        }
    }

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