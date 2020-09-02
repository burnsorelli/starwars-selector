using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Xwing.Styling
{
    class StartPage
    {
        public static Panel FactionPanel = new Panel();
        public static int ButtonWidth = 80;
        public static int ButtonHeight = 20;
        public static Panel ButtonContainerPanel = new Panel();
        private static string _welcomeString = "Welcome to the x-wing squad builder tool";
        private static string _chooseString = "Choose your faction...";
        private static int _internalWidth;
        private static int _internalHeight;
        private static int _buttonContainerWidth = 150;
        private static int _buttonWidth = 80;
        private static int _buttonHeight = 50;
        private static int _border = 20;
        private static int _buttonContainerBorder = 3;

        public static void GetElements()
        {
            
            
            
            _internalWidth = Styling.WholeForm.FormInternalWidth;
            _internalHeight = Styling.WholeForm.FormInternalHeight;
            Label _welcomeText = new Label();
            Label _chooseText = new Label();
            FactionPanel.Visible = true;
            FactionPanel.Size = new Size(_internalWidth, _internalHeight);
            FactionPanel.BackColor = Color.LightGray;
            FactionPanel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, FactionPanel, _border); };

            Styling.WholeForm.TheForm.Controls.Add(FactionPanel);

            _welcomeText.Text = _welcomeString;
            _welcomeText.Font = new Font("Arial", 30);
            _welcomeText.Width = _internalWidth - 2*_border;
            _welcomeText.Height = 150;
            _welcomeText.TextAlign = ContentAlignment.MiddleCenter;
            _welcomeText.Location = new Point(_border, _border);
            FactionPanel.Controls.Add(_welcomeText);

            _chooseText.Text = _chooseString;
            _chooseText.Font = new Font("Arial", 18);
            _chooseText.Width = Styling.WholeForm.FormInternalWidth - 2*_border;
            _chooseText.TextAlign = ContentAlignment.MiddleCenter;
            _chooseText.Location = new Point(_internalWidth / 2 - _chooseText.Width / 2, 
                                             _internalHeight / 2 - 100);
            FactionPanel.Controls.Add(_chooseText);

            ButtonContainerPanel.Size = new Size(_internalWidth - 200, _buttonContainerWidth);
            ButtonContainerPanel.Location = new Point((_internalWidth - ButtonContainerPanel.Width) / 2,
                                                       Convert.ToInt32(0.5*_internalHeight));
            ButtonContainerPanel.BackColor = Color.DarkGray;
            ButtonContainerPanel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, ButtonContainerPanel, _buttonContainerBorder); };
            FactionPanel.Controls.Add(ButtonContainerPanel);

            DataTable tmpDT = Methods.PopulateFactionChoices.GetDataTable();
            int rowCount = 0;
            int count = 1;

            foreach (DataRow row in tmpDT.Rows)
            {
                rowCount += 1;
            }

            int spacePerButton = ButtonContainerPanel.Width / rowCount;

            foreach (DataRow row in tmpDT.Rows)
            {
                int startLocationX;
                int LocationY;
                int LocationX;
                int endLocationX;
                //int endLocationX;

                Button tmpBtn = new Button();
                tmpBtn.Name = row[0].ToString();
                tmpBtn.Text = row[0].ToString();
                tmpBtn.Font = new Font("arial", 10);
                tmpBtn.ForeColor = Color.White;
                tmpBtn.BackColor = Color.Black;
                tmpBtn.Size = new Size(_buttonWidth, _buttonHeight);

                //tmpBtn.FlatStyle = FlatStyle.Standard;
                tmpBtn.FlatAppearance.BorderColor = Color.BlueViolet;
                tmpBtn.FlatAppearance.BorderSize = 2;

                startLocationX = 0 + (count -1) * spacePerButton;
                endLocationX = startLocationX + spacePerButton;
                LocationX = (startLocationX + endLocationX) / 2 - _buttonWidth / 2;
                LocationY = ButtonContainerPanel.Height / 2 - _buttonHeight / 2;

                tmpBtn.Location = new Point(LocationX, LocationY);

                ButtonContainerPanel.Controls.Add(tmpBtn);
                tmpBtn.Click += new EventHandler(EventHandlers.FactionButton.factionButton_Click);
                count += 1;   
            }

            

            tmpDT.Clear();
            tmpDT.Columns.Clear();
            TrackerVariables.TrackedVariables.PilotList.Clear();
        }
        
    }
}
