using System;
using System.ComponentModel;
using POFF.Kicker.Domain;

namespace POFF.Kicker.View;

public class ResultDialogViewModel
{
    public ResultDialogViewModel(Match match)
    {
        if (match is null)
            throw new ArgumentNullException("match");

        Team1 = match.Team1.Name;
        Team2 = match.Team2.Name;

        foreach (var setResult in match.Result.SetResults)
            SetResultInputs.Add(new SetResultInput(setResult));

        Result = new Result();
    }

    public string Team1 { get; }

    public string Team2 { get; }

    public Result Result { get; }

    public BindingList<SetResultInput> SetResultInputs { get; } = [];

    public void FillResult()
    {
        Result.Clear();
        foreach (var setResultInput in SetResultInputs)
        {
            if (setResultInput.Home.HasValue & setResultInput.Guest.HasValue)
            {
                Result.AddSetResult(new SetResult() { Home = (int)setResultInput.Home, Guest = (int)setResultInput.Guest });
            }
        }
    }
}