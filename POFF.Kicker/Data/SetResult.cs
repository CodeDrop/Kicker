using System;

namespace POFF.Kicker.Data;

[Serializable()]
public class SetResult
{

    public int Home { get; set; }
    public int Guest { get; set; }

    public override string ToString()
    {
        return string.Format("{0}:{1}", Home, Guest);
    }
}