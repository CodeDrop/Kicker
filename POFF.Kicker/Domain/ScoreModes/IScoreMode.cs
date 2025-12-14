using System.Collections.Generic;

namespace POFF.Kicker.Domain.ScoreModes;

public interface IScoreMode
{
    IEnumerable<Standing> Evaluate(IEnumerable<Match> matches);
}
