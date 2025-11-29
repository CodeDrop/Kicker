using System;
using System.ComponentModel;
using POFF.Kicker.Data;
using POFF.KickerModel.Types;

namespace POFF.KickerModel.Screens;


public class ResultDialogViewModel
{

    public ResultDialogViewModel(Match match)
    {
        if (match is null)
            throw new ArgumentNullException("match");

        Team1Value = match.Team1.Name;
        Team2Value = match.Team2.Name;

        SetResultInputsValue = new BindingList<SetResultInput>();

        foreach (var setResult in match.Result.SetResults)
            SetResultInputsValue.Add(new SetResultInput(setResult));

        ResultValue = new Result();
    }

    private readonly string Team1Value;
    public string Team1
    {
        get
        {
            return Team1Value;
        }
    }

    private readonly string Team2Value;
    public string Team2
    {
        get
        {
            return Team2Value;
        }
    }

    private readonly BindingList<SetResultInput> SetResultInputsValue;
    public BindingList<SetResultInput> SetResultInputs
    {
        get
        {
            return SetResultInputsValue;
        }
    }

    private readonly Result ResultValue;
    public Result Result
    {
        get
        {
            return ResultValue;
        }
    }

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