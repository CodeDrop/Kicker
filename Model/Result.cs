using System;
using Microsoft.VisualBasic;

namespace POFF.Kicker.Model
{
    [Serializable()]
    public class Result
    {

        public SetResult[] SetResults = new SetResult[0];

        public void AddSetResult(SetResult setResult)
        {
            if (setResult is null)
                throw new ArgumentNullException("setResultRow");

            int goalCount1 = default, goalCount2 = default;

            if (Information.IsNumeric(setResult.Home))
                goalCount1 = int.Parse(setResult.Home.ToString());
            if (Information.IsNumeric(setResult.Guest))
                goalCount2 = int.Parse(setResult.Guest.ToString());

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
}