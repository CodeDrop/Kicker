using System;

namespace POFF.Kicker.Domain;

public class SetResultInput
{
    public SetResultInput()
    {
        Home = default;
        Guest = default;
    }

    public SetResultInput(SetResult setResult)
    {
        if (setResult is null)
            throw new ArgumentNullException("setResult");

        Home = setResult.Home;
        Guest = setResult.Guest;
    }

    public int? Home { get; set; }

    public int? Guest { get; set; }
}