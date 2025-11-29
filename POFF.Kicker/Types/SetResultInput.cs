using System;
using POFF.Kicker.Data;

namespace POFF.KickerModel.Types;


public class SetResultInput
{

    public SetResultInput()
    {
        HomeValue = default;
        GuestValue = default;
    }

    public SetResultInput(SetResult setResult)
    {
        if (setResult is null)
            throw new ArgumentNullException("setResult");

        HomeValue = setResult.Home;
        GuestValue = setResult.Guest;
    }

    private int? HomeValue;
    public int? Home
    {
        get
        {
            return HomeValue;
        }
        set
        {
            HomeValue = value;
        }
    }

    private int? GuestValue;
    public int? Guest
    {
        get
        {
            return GuestValue;
        }
        set
        {
            GuestValue = value;
        }
    }

}