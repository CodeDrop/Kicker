using System;
using POFF.Meet.View;

namespace POFF.Meet.Domain;

public class TeamInfo : NotificationObject
{
    public TeamInfo()
    {
        Name = "New Team";
    }

    public TeamInfo(Team team)
    {
        // Check parameters
        if (team is null)
            throw new ArgumentNullException("team");

        // Initialize members
        Name = team.Name;
        Player1 = team.Player1;
        Player2 = team.Player2;
    }

    public string Name
    {
        get
        {
            return field;
        }
        set
        {
            if ((value ?? "") == (field ?? ""))
                return;
            field = value;
            OnPropertyChanged();
        }
    }

    public string Player1
    {
        get
        {
            return field;
        }
        set
        {
            if ((value ?? "") == (field ?? ""))
                return;
            field = value;
            OnPropertyChanged();
        }
    }

    public string Player2
    {
        get
        {
            return field;
        }
        set
        {
            if ((value ?? "") == (field ?? ""))
                return;
            field = value;
            OnPropertyChanged();
        }
    }

    protected override void OnPropertyChanged(string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);
    }
}