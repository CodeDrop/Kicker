using System;
using System.ComponentModel;
using System.Linq;
using POFF.Kicker.Domain;
using POFF.Kicker.Extensions;

namespace POFF.Kicker.View;

public class ResultDialogViewModel
{
    public ResultDialogViewModel(Match match)
    {
        if (match is null)
            throw new ArgumentNullException("match");

        SetResultInputs.AddRange(match.Result.SetResults.Select(s => new SetResultInput(s)));
    }

    public Result Result { get; } = new Result();

    public BindingList<SetResultInput> SetResultInputs { get; } = [];

    public void FillResult()
    {
        Result.Clear();
        foreach (var setResultInput in SetResultInputs)
        {
            if (setResultInput.Home.HasValue && setResultInput.Guest.HasValue)
            {
                Result.AddSetResult(new SetResult() { Home = (int)setResultInput.Home, Guest = (int)setResultInput.Guest });
            }
        }
    }
}