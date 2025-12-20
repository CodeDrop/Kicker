using System.Windows.Forms;
using POFF.Meet.Domain;

namespace POFF.Meet.View;

public class MatchListViewItem : ListViewItem
{
    public MatchListViewItem(Match match) : base("", (int)match.Status)
    {
        SubItems.Add($"{match.Number}");
        SubItems.Add(match.Team1.Name);
        SubItems.Add(match.Team2.Name);
        SubItems.Add(match.Result.ToString());

        Match = match;
    }

    public Match Match { get; }
}