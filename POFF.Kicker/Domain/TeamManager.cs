using System;

namespace POFF.Kicker.Domain;

public class TeamManager
{
    private Team[] _teams = [];

    public TeamManager(Team[] teams)
    {
        _teams = teams ?? [];
    }

    public Team NewTeam()
    {
        return new Team(_teams.Length + 1);
    }

    public void AddTeam(Team team)
    {
        int index;

        index = _teams.Length;
        Array.Resize(ref _teams, index + 1);
        _teams[index] = team;
    }

    public void RemoveTeam(Team teamToRemove)
    {
        var index = default(int);

        foreach (var team in _teams)
        {
            if (!team.Equals(teamToRemove))
            {
                _teams[index] = team;
                index += 1;
            }
        }

        Array.Resize(ref _teams, index);
    }

    public Team[] GetTeams()
    {
        return _teams;
    }
}