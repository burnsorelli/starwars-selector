using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class PilotSelectedUpgrade
    {
        public static Panel ContainerPanel = new Panel();
        private static int _picPadding = 2;


        public static void GetElements(int _height)
        {
            ContainerPanel.Controls.Clear();
            int _picWidth = Convert.ToInt32(0.5 * Styling.AddPilotPopup.PilotPicture.Width);
            int _picHeight = Convert.ToInt32(0.5 * Styling.AddPilotPopup.PilotPicture.Height);
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            if (TrackerVariables.TrackedVariables.SelectedPilot.Upgrades.Count > 0)
            {
                int _count = 0;
                ContainerPanel.Controls.Clear();
                ContainerPanel.Size = new Size(Styling.AddPilotPopup.ContainerPanel.Width - 2 * Styling.AddPilotPopup.PaddingLeft, 95);
                ContainerPanel.BackColor = Color.CadetBlue;

                foreach(NonStaticClasses.Upgrades _upgrade in _pilot.Upgrades)
                {
                    Panel _upgradePanel = new Panel();
                    _upgradePanel.Size = new Size(60, ContainerPanel.Height - 2 * _picPadding);
                    _upgradePanel.Location = new Point(_count * (_upgradePanel.Width + _picPadding), _picPadding);
                    _upgradePanel.BackColor = Color.Black;
                    ContainerPanel.Controls.Add(_upgradePanel);

                    PictureBox _upgradePicBox = new PictureBox();
                    _upgradePicBox.Size = new Size(_picWidth, _picHeight);
                    _upgradePicBox.Location = new Point((_upgradePanel.Width - _upgradePicBox.Width) / 2,
                                                         _picPadding);
                    _upgradePicBox.BackColor = Color.CadetBlue;
                    _upgradePicBox.Name = _upgrade.Name;
                    bool _add = false;
                    _upgradePicBox.Click += (sender, EventArgs) => { EventHandlers.UpgradeChoicePic.upgrade_Click(sender, EventArgs, _add); };
                    
                    _upgradePicBox.Image = Image.FromFile(_upgrade.UpgradePicLocation);
                    _upgradePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    _upgradePicBox.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
                    _upgradePicBox.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
                    _upgradePanel.Controls.Add(_upgradePicBox);

                    Label _upgradeName = new Label();
                    _upgradeName.Size = new Size(_upgradePanel.Width, Convert.ToInt32(0.13 * _upgradePanel.Height));
                    _upgradeName.Location = new Point(0, _upgradePicBox.Height + 2 * _picPadding);
                    _upgradeName.Text = _upgrade.Name;
                    _upgradeName.Font = new Font("Arial", Convert.ToInt32(6.5));
                    _upgradeName.TextAlign = ContentAlignment.MiddleCenter;
                    _upgradeName.BackColor = Color.Green;
                    _upgradePanel.Controls.Add(_upgradeName);

                    Label _upgradeType = new Label();
                    _upgradeType.Size = new Size(_upgradePanel.Width, Convert.ToInt32(0.17 * _upgradePanel.Height));
                    _upgradeType.Location = new Point(0, _upgradePicBox.Height + _upgradeName.Height + 2 * _picPadding);
                    _upgradeType.Text = _upgrade.Type;
                    _upgradeType.Font = new Font("Arial", Convert.ToInt32(6.5));
                    _upgradeType.BackColor = Color.LightGray;
                    _upgradeType.TextAlign = ContentAlignment.MiddleCenter;
                    _upgradePanel.Controls.Add(_upgradeType);

                    _count += 1;
                    
                }
                Styling.AddPilotPopup.ContainerPanel.Size = new Size(400, 300);
            }
            else
            {
                ContainerPanel.Size = new Size(0, 0);
                Styling.AddPilotPopup.ContainerPanel.Size = new Size(400, 210);
            }

            Tuple<int, int> _location = Methods.GetPopupLocation.GetLocation(Styling.AddPilotPopup.ContainerPanel);
            Styling.AddPilotPopup.ContainerPanel.Location = new Point(_location.Item1, _location.Item2);
            ContainerPanel.Location = new Point(Styling.AddPilotPopup.PaddingLeft, _height);
            Styling.AddPilotPopup.ContainerPanel.Controls.Add(ContainerPanel);
        }
    }
}
