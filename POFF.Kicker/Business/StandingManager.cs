using System;
using System.Collections.Generic;

namespace POFF.Kicker.Model
{
    public class StandingManager
    {

        public Standing[] GetStandings(Match[] finishedMatches)
        {
            var list = new Dictionary<Team, Standing>();
            int[] setsWon = new int[0], points = new int[0], goals = new int[0];

            foreach (var finishedMatch in finishedMatches)
            {
                setsWon = new int[2];
                points = new int[2];
                goals = new int[2];

                if (!list.ContainsKey(finishedMatch.Team1))
                    list.Add(finishedMatch.Team1, new Standing(finishedMatch.Team1));
                if (!list.ContainsKey(finishedMatch.Team2))
                    list.Add(finishedMatch.Team2, new Standing(finishedMatch.Team2));

                foreach (var setResult in finishedMatch.Result.SetResults)
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

                {
                    var withBlock = list[finishedMatch.Team1];
                    withBlock.MatchCount += 1;
                    withBlock.Points += points[0];
                    withBlock.WonSetCount += setsWon[0];
                    withBlock.Goals += goals[0];
                    withBlock.GoalsAgainst += goals[1];
                }
                {
                    var withBlock1 = list[finishedMatch.Team2];
                    withBlock1.MatchCount += 1;
                    withBlock1.Points += points[1];
                    withBlock1.WonSetCount += setsWon[1];
                    withBlock1.Goals += goals[1];
                    withBlock1.GoalsAgainst += goals[0];
                }
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
}