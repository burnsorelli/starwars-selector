using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class HeaderOutline
    {
        public static Panel ContainerPanel = new Panel();
        public static Panel ChosenSquadPanel = new Panel();
        public static Panel TotalScorePanel = new Panel();
        public static int TotalScorePanelPadding = 20;
        private static Label _chosenSquadLabel = new Label();
        private static int _containerBorder = 3;

        public static void GetElements()
        {
            int _widthContainer = Styling.MainPageOutline.HeaderPanel.Width;
            int _heightContainer = Styling.MainPageOutline.HeaderPanel.Height;

            ContainerPanel.Size = new Size(_widthContainer, _heightContainer);
            ContainerPanel.Location = new Point(0, 0);
            ContainerPanel.BackColor = Color.Black;
            Styling.MainPageOutline.HeaderPanel.Controls.Add(ContainerPanel);

            _chosenSquadLabel.Location = new Point(_containerBorder,_containerBorder);
            _chosenSquadLabel.AutoSize = true;
            _chosenSquadLabel.Text = "Your " + TrackerVariables.TrackedVariables.FactionChosen + " squad...";
            _chosenSquadLabel.Font = new Font("Arial", 12);
            _chosenSquadLabel.BackColor = Color.LightGray;
            ContainerPanel.Controls.Add(_chosenSquadLabel);

            ChosenSquadPanel.Size = new Size(Convert.ToInt32(0.8 * Styling.MainPageOutline.HeaderPanel.Width) -2*_containerBorder,
                                             Styling.MainPageOutline.HeaderPanel.Height - _chosenSquadLabel.Height -2* _containerBorder);
            ChosenSquadPanel.Location = new Point(_containerBorder, _chosenSquadLabel.Height+_containerBorder);
            ChosenSquadPanel.BackColor = Color.LightGray;
            ContainerPanel.Controls.Add(ChosenSquadPanel);

            TotalScorePanel.Size = new Size(Convert.ToInt32(0.2 * Styling.MainPageOutline.HeaderPanel.Width), 
                                            ContainerPanel.Height);
            TotalScorePanel.Location = new Point(ChosenSquadPanel.Width + 2*_containerBorder, 0);
            TotalScorePanel.BackColor = Color.LightGray;
            TotalScorePanel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, TotalScorePanel, TotalScorePanelPadding); };
            ContainerPanel.Controls.Add(TotalScorePanel);

            Styling.HeaderSquadSelected.GetElements();
        }
    }
}
