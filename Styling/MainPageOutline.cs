using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class MainPageOutline
    {
        public static Panel ContainerPanel = new Panel();
        public static Panel HeaderPanel = new Panel();
        public static Panel ChoicesDisplayedPanel = new Panel();

        private static int _squadSelectedPanelHeight = 150;

        //private static Button _backButton = new Button();
        //private static string _backToFactionText = "Return to faction choice";
        //private static int _buttonWidth = 150;
        //private static int _buttonHeight = 20;
        private static int _containerBorder = 5;

        public static void GetElements()
        {
            int _formInternalWidth = Styling.WholeForm.FormInternalWidth;
            int _formInternalHeight = Styling.WholeForm.FormInternalHeight;


            ContainerPanel.Visible = true;
            ContainerPanel.Size = new Size(_formInternalWidth, _formInternalHeight);
            ContainerPanel.Location = new Point(0, 0);
            Styling.WholeForm.TheForm.Controls.Add(ContainerPanel);

            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Size = new Size(_formInternalWidth, _squadSelectedPanelHeight);
            HeaderPanel.BackColor = Color.Turquoise;
            ContainerPanel.Controls.Add(HeaderPanel);

            ChoicesDisplayedPanel.Location = new Point(0, _squadSelectedPanelHeight);
            ChoicesDisplayedPanel.Size = new Size(_formInternalWidth, 
                                                  _formInternalHeight - _squadSelectedPanelHeight);
            ChoicesDisplayedPanel.BackColor = Color.DarkGray;
            ChoicesDisplayedPanel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, ChoicesDisplayedPanel, _containerBorder); };
            ContainerPanel.Controls.Add(ChoicesDisplayedPanel);


            // new from here
            //_backButton.Text = _backToFactionText;
            //_backButton.Width = _buttonWidth;
            //_backButton.Height = _buttonHeight;
            //_backButton.Location = new Point(ChoicesDisplayedPanel.Width - _buttonWidth - _containerBorder,
            //                                 ChoicesDisplayedPanel.Height - _buttonHeight - _containerBorder);
            //Methods.RemoveEventHandlers.RemoveAllHandlers(_backButton);
            //_backButton.Click += new EventHandler(EventHandlers.BackToFactionButton.backFaction_Click);
            //_backButton.BackColor = Color.LightSalmon;
            //ChoicesDisplayedPanel.Controls.Add(_backButton);

        }
    }
}
