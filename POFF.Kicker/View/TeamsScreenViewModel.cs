using System;
using System.Collections.Generic;
using System.ComponentModel;
using POFF.Kicker.Domain;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.View;


public class TeamsScreenViewModel : ViewModelBase
{

    public TeamsScreenViewModel(Tournament tournament)
    {
        // Check parameters
        if (tournament is null)
            throw new ArgumentNullException("tournament");

        // Initialize members
        TournamentValue = tournament;
        TeamsValue = new BindingList<Team>([.. tournament.Teams]) { RaiseListChangedEvents = true };
        ConfirmationMessageHandlerValue = DefaultConfirmationMessageHandler.Empty;
    }

    private readonly Tournament TournamentValue;
    public Tournament Tournament
    {
        get
        {
            return TournamentValue;
        }
    }

    private BindingList<Team> TeamsValue;
    public BindingList<Team> Teams
    {
        get
        {
            return TeamsValue;
        }
    }

    private IConfirmationMessage ConfirmationMessageHandlerValue;
    public IConfirmationMessage ConfirmationMessageHandler
    {
        get
        {
            return ConfirmationMessageHandlerValue;
        }
        set
        {
            if (value is null)
                throw new ArgumentException("ConfirmationMessageHandler must not be null");
            ConfirmationMessageHandlerValue = value;
        }
    }

    public void AddTeam(Team team)
    {
        Tournament.AddTeam(team);
        Teams.Add(team);
    }

    public void RemoveTeam(Team team)
    {
        string message = string.Format("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie die Mannschaft \"{1}\" entfernen.{0}{0}Wollen Sie die Manschaft entfernen?", Environment.NewLine, team.Name);
        if (ConfirmationMessageHandler.Confirm(message))
        {
            Tournament.RemoveTeam(team);
            Teams.Remove(team);
        }
    }

    public void ToggleTeamStatus(Team team)
    {
        team.Withdrawn = !team.Withdrawn;
    }

}