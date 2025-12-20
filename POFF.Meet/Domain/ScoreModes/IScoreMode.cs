using System.Collections.Generic;

namespace POFF.Meet.Domain.ScoreModes;

public interface IScoreMode
{
    IEnumerable<Standing> Evaluate(IEnumerable<Match> matches);
}
