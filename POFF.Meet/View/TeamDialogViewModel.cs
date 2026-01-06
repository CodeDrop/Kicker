using System;
using POFF.Meet.Domain;

namespace POFF.Meet.View;

public class TeamDialogViewModel
{
    public TeamDialogViewModel(TeamInfo teamInfo)
    {
        // Check parameters
        if (teamInfo is null)
            throw new ArgumentNullException("teamInfo");

        // Initialize members
        _teamInfo = teamInfo;
    }

    private readonly TeamInfo _teamInfo;
    private TeamInfo TeamInfo
    {
        get
        {
            return _teamInfo;
        }
    }
}