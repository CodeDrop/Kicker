using System;
using POFF.Kicker.Types;

namespace POFF.Kicker.View;


public class TeamDialogViewModel
{

    public TeamDialogViewModel(TeamInfo teamInfo)
    {
        // Check parameters
        if (teamInfo is null)
            throw new ArgumentNullException("teamInfo");

        // Initialize members
        TeamInfoValue = teamInfo;
    }

    private readonly TeamInfo TeamInfoValue;
    private TeamInfo TeamInfo
    {
        get
        {
            return TeamInfoValue;
        }
    }

    public void AcceptChanges()
    {
        TeamInfo.AcceptChanges();
    }

}