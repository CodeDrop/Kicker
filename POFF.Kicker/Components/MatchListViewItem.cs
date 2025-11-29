using System.Windows.Forms;
using POFF.Kicker.Model;

namespace POFF.Kicker.View.Components;


public class MatchListViewItem : ListViewItem
{

    public MatchListViewItem(Match match, int matchNo = 0) : base("", (int)match.Status)
    {
        SubItems.Add($"{matchNo}");
        SubItems.Add(match.Team1.Name);
        SubItems.Add(match.Team2.Name);
        SubItems.Add(match.Result.ToString());

        MatchValue = match;
    }

    private Match MatchValue;
    public Match Match
    {
        get
        {
            return MatchValue;
        }
    }

    internal void RefreshNumber()
    {
        SubItems[1].Text = $"{Index + 1}";
    }

}