using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class AddUpgradePopup
    {
        public static Panel ContainerPanel = new Panel();
        private static int _containerPanelWidth = 400;
        private static int _containerPanelHeight = 210;

        public static Button AddUpgradeButton = new Button();
        private static int _buttonHeight = 40;
        private static int _buttonWidth = 75;
        private static int _buttonPadding = 10;

        private static Button _closeButton = new Button();
        private static string _closeButtonText = "Close";

        private static Panel _upgradePanel = new Panel();
        private static int _upgradePanelWidth = 100;
        private static int _upgradePanelHeight = 150;

        private static PictureBox _pilotPicture = new PictureBox();

        private static Label _upgradeName = new Label();

        private static TextBox _upgradeDetails = new TextBox();

        public static void GetElements(bool _add)
        {
            var _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;
            

            ContainerPanel.Size = new Size(_containerPanelWidth, _containerPanelHeight);
            Tuple<int, int> _location = Methods.GetPopupLocation.GetLocation(ContainerPanel);
            ContainerPanel.Location = new Point(_location.Item1, _location.Item2);
            Styling.WholeForm.TheForm.Controls.Add(ContainerPanel);

            _upgradePanel.Size = new Size(_upgradePanelWidth, _upgradePanelHeight);
            _upgradePanel.Location = new Point(5, 5);
            ContainerPanel.Controls.Add(_upgradePanel);

            _pilotPicture.Location = new Point(0, 0);
            _pilotPicture.Size = new Size(_upgradePanelWidth, _upgradePanelHeight - _upgradeName.Height);
            _pilotPicture.BackColor = Color.CadetBlue;
            //_pilotPicture.Image = Image.FromFile("c:/Users/Burns/source/repos/Xwing/Xwing/Images/Pilots/alpha_squadron_pilot.png");
            _pilotPicture.Image = Image.FromFile(_upgrade.UpgradePicLocation);
            _pilotPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            _pilotPicture.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
            _pilotPicture.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
            _upgradePanel.Controls.Add(_pilotPicture);

            _upgradeName.Location = new Point(0, _pilotPicture.Height);
            _upgradeName.Text = _upgrade.Name;
            _upgradeName.TextAlign = ContentAlignment.MiddleCenter;
            _upgradePanel.Controls.Add(_upgradeName);

            _upgradeDetails.Location = new Point(_upgradePanel.Location.X + _upgradePanelWidth + _buttonPadding,
                                                 _upgradePanel.Location.Y);
            _upgradeDetails.Size = new Size(200, _upgradePanelHeight);
            _upgradeDetails.Text = Methods.GetUpgradeDetailsString.GetDetails();
            _upgradeDetails.BackColor = Color.White;
            _upgradeDetails.ReadOnly = true;
            _upgradeDetails.Multiline = true;
            _upgradeDetails.Enabled = false;
            _upgradeDetails.ScrollBars = ScrollBars.Vertical;
            _upgradeDetails.Font = new Font("Arial", 9);
            ContainerPanel.Controls.Add(_upgradeDetails);

            AddUpgradeButton.Location = new Point(_upgradePanel.Location.X,
                                                  _upgradePanel.Location.Y + _upgradePanelHeight + _buttonPadding);
            AddUpgradeButton.Size = new Size(_buttonWidth, _buttonHeight);
            if (_add)
            {
                AddUpgradeButton.Text = "Add upgrade";
            }
            else
            {
                AddUpgradeButton.Text = "Remove upgrade";
            }
            AddUpgradeButton.Click += (sender, EventArgs) => { EventHandlers.AddUpgradeButton.addUpgrade_Click(sender, EventArgs, _add); };
            ContainerPanel.Controls.Add(AddUpgradeButton);

            _closeButton.Location = new Point(_upgradePanel.Location.X + _buttonWidth + _buttonPadding,
                                              _upgradePanel.Location.Y + _upgradePanelHeight + _buttonPadding);
            _closeButton.Size = new Size(_buttonWidth, _buttonHeight);
            _closeButton.Text = _closeButtonText;
            _closeButton.Click += new EventHandler(EventHandlers.CloseUpgradePopup.closeButton_Click);
            ContainerPanel.Controls.Add(_closeButton);
            ContainerPanel.BringToFront();
            ContainerPanel.Visible = true;
            Methods.ControlsActive.DisableControls(ContainerPanel);
        }
    }
}
