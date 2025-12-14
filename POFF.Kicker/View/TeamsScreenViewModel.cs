using System;
using System.ComponentModel;
using POFF.Kicker.Domain;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.View;

public class TeamsScreenViewModel : ViewModelBase
{
    public TeamsScreenViewModel()
    {
        // Check parameters
        ConfirmationMessageHandlerValue = DefaultConfirmationMessageHandler.Empty;
    }

    public void SetTournament(Tournament tournament)
    {
        if (tournament is null)
            throw new ArgumentNullException("tournament");

        // Initialize members
        _tournament = tournament;
        Teams.Clear();
        foreach (Team team in tournament.Teams)
            Teams.Add(team);
    }

    private Tournament _tournament;

    public BindingList<Team> Teams { get; } = new();

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
        _tournament.AddTeam(team);
        Teams.Add(team);
    }

    public void RemoveTeam(Team team)
    {
        string message = string.Format("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie die Mannschaft \"{1}\" entfernen.{0}{0}Wollen Sie die Manschaft entfernen?", Environment.NewLine, team.Name);
        if (ConfirmationMessageHandler.Confirm(message))
        {
            _tournament.RemoveTeam(team);
            Teams.Remove(team);
        }
    }

    public void ToggleTeamStatus(Team team)
    {
        team.Withdrawn = !team.Withdrawn;
    }
}