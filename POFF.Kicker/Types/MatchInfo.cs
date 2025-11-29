using System;
using POFF.Kicker.Data;

namespace POFF.Kicker;


public class MatchInfo
{

    public MatchInfo(Match match)
    {
        // Check parameters
        if (match is null)
            throw new ArgumentNullException("match");

        // Initializes members
        MatchValue = match;
        Team1NameValue = match.Team1.Name;
        Team2NameValue = match.Team2.Name;
        ResultSummaryValue = match.Result.ToString();
    }

    private readonly Match MatchValue;
    internal Match Match
    {
        get
        {
            return MatchValue;
        }
    }

    private readonly string Team1NameValue;
    public string Team1Name
    {
        get
        {
            return Team1NameValue;
        }
    }

    private readonly string Team2NameValue;
    public string Team2Name
    {
        get
        {
            return Team2NameValue;
        }
    }

    private readonly string ResultSummaryValue;
    public string ResultSummary
    {
        get
        {
            return ResultSummaryValue;
        }
    }

}