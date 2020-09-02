using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Xwing.Styling
{
    class HeaderTotalScore
    {
        public static Label ScoreLabel = new Label();
        private static Label _scoreDescriptionLabel = new Label();
        private static int _internalPadding;
        private static int _scoreHeight = 60;
        private static int _scoreWidth = 60;
        private static int _scoreLabelHeight = 40;
        //private static int _scorePadding = 15;

        public static void GetElements()
        {
            _internalPadding = Styling.HeaderOutline.TotalScorePanelPadding;
            var scoreX = (Styling.HeaderOutline.TotalScorePanel.Width - _scoreWidth) / 2;
            var scoreY = (Styling.HeaderOutline.TotalScorePanel.Height - _scoreHeight - _internalPadding/2 ) / 2;

            ScoreLabel.Location = new Point(scoreX, scoreY);
            ScoreLabel.Size = new Size(_scoreWidth, _scoreHeight);
            

            //ScoreLabel.Padding = new Padding(0, 2 * _padding, 0, 0);
            ScoreLabel.Text = "0";
            ScoreLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            ScoreLabel.BackColor = Color.LightGray;
            ScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            ScoreLabel.ForeColor = Color.Black;
            

            Styling.HeaderOutline.TotalScorePanel.Controls.Add(ScoreLabel);

            //ScoreLabel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, ScoreLabel, _scorePadding); };

            _scoreDescriptionLabel.Size = new Size(Styling.HeaderOutline.TotalScorePanel.Width - 2*_internalPadding, _scoreLabelHeight);
            _scoreDescriptionLabel.Location = new Point(_internalPadding, Styling.HeaderOutline.TotalScorePanel.Height - _scoreDescriptionLabel.Height - _internalPadding);
            //_scoreDescriptionLabel.Dock = DockStyle.Bottom;
            //_scoreDescriptionLabel.Padding = new Padding(0, 0, 0, _padding);
            _scoreDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            _scoreDescriptionLabel.BackColor = Color.LightGray;
            _scoreDescriptionLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            _scoreDescriptionLabel.Text = "Total Score";
            Styling.HeaderOutline.TotalScorePanel.Controls.Add(_scoreDescriptionLabel);
        }
    }
}
