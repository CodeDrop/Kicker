using System.Windows.Forms;
using POFF.Kicker.Model;

namespace POFF.Kicker.View.Components
{

    public class StandingListViewItem : ListViewItem
    {

        public StandingListViewItem(Standing standing) : base(standing.Place.ToString())
        {
            SubItems.Add(standing.Team.Name);
            SubItems.Add(standing.Points.ToString());
            SubItems.Add(standing.WonSetCount.ToString());
            SubItems.Add(string.Format("{0}:{1}", standing.Goals, standing.GoalsAgainst));
            SubItems.Add(standing.MatchCount.ToString());

            StandingValue = standing;
        }

        private readonly Standing StandingValue;
        public Standing Standing
        {
            get
            {
                return StandingValue;
            }
        }

    }

}