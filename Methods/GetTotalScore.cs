using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Xwing.Methods
{
    class GetTotalScore
    {
        public static void GetScore()
        {
            int _totalScore = 0;

            foreach(NonStaticClasses.Pilots _pilot in TrackerVariables.TrackedVariables.PilotList)
            {
                if (_pilot.Upgrades != null)
                {
                    foreach(NonStaticClasses.Upgrades _upgrade in _pilot.Upgrades)
                    {
                        _totalScore += _upgrade.Points;
                    }
                }
                _totalScore += _pilot.Points;
            }
            Styling.HeaderTotalScore.ScoreLabel.Text = _totalScore.ToString();
            if(Convert.ToInt32(Styling.HeaderTotalScore.ScoreLabel.Text) > TrackerVariables.TrackedVariables.MaxPoints)
            {
                Styling.HeaderTotalScore.ScoreLabel.ForeColor = Color.Red;
            }
            else
            {
                Styling.HeaderTotalScore.ScoreLabel.ForeColor = Color.Black;
            }
        }
    }
}
