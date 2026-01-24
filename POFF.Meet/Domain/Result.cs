using System;

namespace POFF.Meet.Domain;

public class Result
{
    public SetResult[] SetResults = [];

    public void AddSetResult(SetResult setResult)
    {
        if (setResult is null)
            throw new ArgumentNullException("setResultRow");

        int goalCount1 = default, goalCount2 = default;

        goalCount1 = setResult.Home;
        goalCount2 = setResult.Guest;

        Array.Resize(ref SetResults, SetResults.Length + 1);
        SetResults[SetResults.Length - 1] = new SetResult();
        SetResults[SetResults.Length - 1].Home = goalCount1;
        SetResults[SetResults.Length - 1].Guest = goalCount2;
    }

    public void Clear()
    {
        Array.Resize(ref SetResults, 0);
    }

    public override string ToString()
    {
        if (SetResults.Length == 0)
            return "";

        var resultString = new System.Text.StringBuilder();

        foreach (var setResult in SetResults)
            resultString.AppendFormat("/{0}", setResult);

        return resultString.ToString().Substring(1);
    }
}