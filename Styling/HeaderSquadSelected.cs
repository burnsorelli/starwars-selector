using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class HeaderSquadSelected
    {


        //private static int _count = 1;
        private static int _containerWidth = 76;
        private static int _containerHeight = 120;
        private static int _containerPaddingTop = 5;
        private static int _containerPaddingLeft = 3;
        private static int _labelHeight = 30;
        private static int _hasUpgradesHeightWidth = 15;

        public static void GetElements()
        {
            //int _picHeight = (3 * Styling.MainPageChoices._displayPicHeight) / 4;
            //int _picWidth = (3 * Styling.MainPageChoices._displayPicWidth) / 4;
            int _picHeight = (3 * Styling.MainPageChoices._displayPicHeight) / 4;
            int _picWidth = (3 * Styling.MainPageChoices._displayPicWidth) / 4;

            int _picPosX = (_containerWidth - _picWidth) / 2;
            int _picPosY = (_containerHeight - _picHeight - _labelHeight) / 2;
            int _count = 1;
            Styling.HeaderOutline.ChosenSquadPanel.Controls.Clear();

            foreach (NonStaticClasses.Pilots _pilot in TrackerVariables.TrackedVariables.PilotList)
            {
                
                Panel tmpContainerPanel = new Panel();
                PictureBox tmpPictureBox = new PictureBox();
                Label tmpNameLabel = new Label();
                Label tmpHasUpgradesLabel = new Label();

                tmpContainerPanel.Size = new Size(_containerWidth, _containerHeight);
                tmpContainerPanel.Location = new Point(((_count - 1) * (_containerWidth + _containerPaddingLeft)) + _containerPaddingLeft, _containerPaddingTop);
                tmpContainerPanel.BackColor = Color.Black;
                Styling.HeaderOutline.ChosenSquadPanel.Controls.Add(tmpContainerPanel);
                
                tmpPictureBox.Name = _pilot.UniqueId.ToString();
                tmpPictureBox.Size = new Size(_picWidth, _picHeight);
                tmpPictureBox.Location = new Point(_picPosX, _picPosY);
                tmpPictureBox.BackColor = Color.CadetBlue;
                tmpPictureBox.Click += (sender, EventArgs) => { EventHandlers.SquadSelectedPilotPic.pic_Click(sender, EventArgs, false); };
                tmpPictureBox.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
                tmpPictureBox.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
                tmpPictureBox.Image = Image.FromFile(_pilot.PilotPicLocation);
                tmpPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                tmpContainerPanel.Controls.Add(tmpPictureBox);

                tmpNameLabel.Text = _pilot.Name;
                tmpNameLabel.Font = new Font("Arial", Convert.ToInt32(6.8));
                tmpNameLabel.Size = new Size(_containerWidth, _labelHeight);
                tmpNameLabel.Location = new Point(0, _containerHeight - _labelHeight);
                tmpNameLabel.BackColor = Color.White;
                tmpNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                tmpContainerPanel.Controls.Add(tmpNameLabel);

                if (_pilot.Upgrades.Count() > 0)
                {
                    tmpHasUpgradesLabel.Size = new Size(_hasUpgradesHeightWidth, _hasUpgradesHeightWidth);
                    tmpHasUpgradesLabel.Location = new Point(tmpPictureBox.Width - _hasUpgradesHeightWidth, tmpPictureBox.Height - _hasUpgradesHeightWidth);
                    tmpHasUpgradesLabel.BackColor = Color.Yellow;
                    tmpHasUpgradesLabel.Text = _pilot.Upgrades.Count().ToString();
                    tmpHasUpgradesLabel.TextAlign = ContentAlignment.MiddleCenter;
                    tmpPictureBox.Controls.Add(tmpHasUpgradesLabel);
                }

                _count += 1;
            }

        }

    }
}
