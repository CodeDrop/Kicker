using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using System;

namespace POFF.Kicker.Domain;

public class TeamManager
{

    public TeamManager()
    {
        Load();
    }

    private Team[] Teams = new Team[0];

    public Team NewTeam()
    {
        return new Team(Teams.Length + 1);
    }

    public void AddTeam(Team team)
    {
        int index;

        index = Teams.Length;
        Array.Resize(ref Teams, index + 1);
        Teams[index] = team;
    }

    public void RemoveTeam(Team teamToRemove)
    {
        var index = default(int);

        foreach (var team in Teams)
        {
            if (!team.Equals(teamToRemove))
            {
                Teams[index] = team;
                index += 1;
            }
        }

        Array.Resize(ref Teams, index);
    }

    public Team[] GetTeams()
    {
        return Teams;
    }

    private void Load()
    {
        var data = Database.Load(typeof(Team[]));
        if (data is not null)
            Teams = (Team[])data;
    }

}