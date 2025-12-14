using System;
using System.Collections.Generic;

namespace POFF.Kicker.Domain.ScoreModes;

public class Win3Equal1Loss0ScoreMode : IScoreMode
{
    public IEnumerable<Standing> Evaluate(IEnumerable<Match> matches)
    {
        var list = new Dictionary<Team, Standing>();
        int[] setsWon, points, goals;

        foreach (var match in matches)
        {
            setsWon = new int[2];
            points = new int[2];
            goals = new int[2];

            if (!list.ContainsKey(match.Team1))
                list.Add(match.Team1, new Standing(match.Team1));
            if (!list.ContainsKey(match.Team2))
                list.Add(match.Team2, new Standing(match.Team2));

            foreach (var setResult in match.Result.SetResults)
            {
                switch (setResult.Home.CompareTo(setResult.Guest))
                {
                    case var @case when @case > 0:
                        {
                            setsWon[0] += 1;
                            break;
                        }
                    case var case1 when case1 < 0:
                        {
                            setsWon[1] += 1;
                            break;
                        }
                }

                goals[0] += setResult.Home;
                goals[1] += setResult.Guest;
            }

            switch (setsWon[0].CompareTo(setsWon[1]))
            {
                case var case2 when case2 > 0:
                    {
                        points[0] += 3;
                        break;
                    }
                case 0:
                    {
                        points[0] += 1;
                        points[1] += 1;
                        break;
                    }
                case var case3 when case3 < 0:
                    {
                        points[1] += 3;
                        break;
                    }
            }

            var standing1 = list[match.Team1];
            standing1.MatchCount += 1;
            standing1.Points += points[0];
            standing1.WonSetCount += setsWon[0];
            standing1.Goals += goals[0];
            standing1.GoalsAgainst += goals[1];

            var standing2 = list[match.Team2];
            standing2.MatchCount += 1;
            standing2.Points += points[1];
            standing2.WonSetCount += setsWon[1];
            standing2.Goals += goals[1];
            standing2.GoalsAgainst += goals[0];
        }

        // Set place numbers 
        var standings = new Standing[list.Count];

        var tempArray = Array.CreateInstance(typeof(Standing), list.Count);
        list.Values.CopyTo((Standing[])tempArray, 0);                   // Copy hashtable to array
        Array.Sort(tempArray);                       // Sort 
        for (int index = 0, loopTo = tempArray.Length - 1; index <= loopTo; index++)
        {
            standings[index] = (Standing)tempArray.GetValue(index);
            standings[index].Place = index + 1;      // Set place number
        }

        return standings;
    }
}