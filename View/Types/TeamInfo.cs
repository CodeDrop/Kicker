using System;
using System.ComponentModel;
using POFF.Kicker.Model;

namespace POFF.Kicker.ViewModel.Types
{

    public class TeamInfo : NotificationObject, IChangeTracking
    {

        public TeamInfo() : this(new Team() { Name = "New Team" })
        {
        }

        public TeamInfo(Team team)
        {
            // Check parameters
            if (team is null)
                throw new ArgumentNullException("team");

            // Initialize members
            TeamValue = team;
            Current.Name = team.Name;
            Current.Player1 = team.Player1;
            Current.Player2 = team.Player2;
        }

        private Data Current;

        private struct Data
        {
            public string Name;
            public string Player1;
            public string Player2;
        }

        private readonly Team TeamValue;
        internal Team Team
        {
            get
            {
                return TeamValue;
            }
        }

        public string Name
        {
            get
            {
                return Current.Name;
            }
            set
            {
                if ((value ?? "") == (Current.Name ?? ""))
                    return;
                Current.Name = value;
                OnPropertyChanged();
            }
        }

        public string Player1
        {
            get
            {
                return Current.Player1;
            }
            set
            {
                if ((value ?? "") == (Current.Player1 ?? ""))
                    return;
                Current.Player1 = value;
                OnPropertyChanged();
            }
        }

        public string Player2
        {
            get
            {
                return Current.Player2;
            }
            set
            {
                if ((value ?? "") == (Current.Player2 ?? ""))
                    return;
                Current.Player2 = value;
                OnPropertyChanged();
            }
        }

        protected override void OnPropertyChanged(string propertyName = "")
        {
            IsChangedValue = true;
            base.OnPropertyChanged(propertyName);
        }

        public void AcceptChanges()
        {
            Team.Name = Current.Name;
            Team.Player1 = Current.Player1;
            Team.Player2 = Current.Player2;
        }

        private bool IsChangedValue;
        public bool IsChanged
        {
            get
            {
                return IsChangedValue;
            }
        }

    }

}