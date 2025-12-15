using System;
using System.ComponentModel;
using POFF.Kicker.Domain;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.View;

public class TeamsScreenViewModel : ViewModelBase
{
    public TeamsScreenViewModel()
    {
        ConfirmationMessageHandler = DefaultConfirmationMessageHandler.Empty;
    }

    public void SetTournament(Tournament tournament)
    {
        if (tournament is null)
            throw new ArgumentNullException("tournament");

        // Initialize members
        Teams.Clear();
        foreach (Team team in tournament.Teams)
            Teams.Add(team);
    }

    public BindingList<Team> Teams { get; } = [];

    public IConfirmationMessage ConfirmationMessageHandler
    {
        get
        {
            return field;
        }
        set
        {
            field = value ?? throw new ArgumentException("ConfirmationMessageHandler must not be null");
        }
    }

    public TeamInfo SelectedTeam { get; internal set; }

    public void ToggleTeamStatus(Team team)
    {
        team.Withdrawn = !team.Withdrawn;
    }
}