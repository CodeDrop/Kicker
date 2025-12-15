using System;
using System.ComponentModel;
using POFF.Kicker.View;

namespace POFF.Kicker.Domain;

public class TeamInfo : NotificationObject, IChangeTracking
{
    private Data _current;
    private readonly Team _team;

    public TeamInfo() : this(new Team() { Name = "New Team" })
    {
    }

    public TeamInfo(Team team)
    {
        // Check parameters
        if (team is null)
            throw new ArgumentNullException("team");

        // Initialize members
        _team = team;
        _current.Name = team.Name;
        _current.Player1 = team.Player1;
        _current.Player2 = team.Player2;
    }

    private struct Data
    {
        public string Name;
        public string Player1;
        public string Player2;
    }

    internal Team Team
    {
        get
        {
            return _team;
        }
    }

    public string Name
    {
        get
        {
            return _current.Name;
        }
        set
        {
            if ((value ?? "") == (_current.Name ?? ""))
                return;
            _current.Name = value;
            OnPropertyChanged();
        }
    }

    public string Player1
    {
        get
        {
            return _current.Player1;
        }
        set
        {
            if ((value ?? "") == (_current.Player1 ?? ""))
                return;
            _current.Player1 = value;
            OnPropertyChanged();
        }
    }

    public string Player2
    {
        get
        {
            return _current.Player2;
        }
        set
        {
            if ((value ?? "") == (_current.Player2 ?? ""))
                return;
            _current.Player2 = value;
            OnPropertyChanged();
        }
    }

    protected override void OnPropertyChanged(string propertyName = "")
    {
        IsChanged = true;
        base.OnPropertyChanged(propertyName);
    }

    public void AcceptChanges()
    {
        Team.Name = _current.Name;
        Team.Player1 = _current.Player1;
        Team.Player2 = _current.Player2;
    }

    public bool IsChanged { get; private set; }
}