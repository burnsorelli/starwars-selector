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
    class MainPageChoices
    {
        //private static Button _backButton = new Button();
        public static Panel ContainerPanel = new Panel();
        private static int _padding = 20;
        //private static string _backToFactionText = "Return to faction choice";
        //private static int _buttonWidth = 150;
        //private static int _buttonHeight = 20;

        private static Button _backButton = new Button();
        private static string _backToFactionText = "Return to faction choice";
        private static int _buttonWidth = 150;
        private static int _buttonHeight = 20;
        private static int _containerBorder = 5;

        private static int _backToButtonHeight = 35;
        private static int _backToButtonWidth = 100;
        private static string _backToShipText = "Back to ships";
        private static string _backToPilotText = "Back to pilots";
        private static string _backToUpgradeCatsText = "Back to upgrade types";

        private static int _choicePanelHeight = 150;
        private static int _choicePanelWidth = 100;
        private static int _choicePanelPaddingWidth = 5;
        private static int _choicePanelPaddingHeight = 4;
        private static int _labelHeight = 28;
        private static int _internalPadding = 4;
        //public static PictureBox _displayPic = new PictureBox();
        public static int _displayPicHeight;
        public static int _displayPicWidth;

        public static void GetElements(DataTable _dataTable = null, string _type = null, List<string> _upgradeType = null)
        {
            
            Panel tmpParent = Styling.MainPageOutline.ChoicesDisplayedPanel;
            tmpParent.Controls.Clear();


            _backButton.Text = _backToFactionText;
            _backButton.Width = _buttonWidth;
            _backButton.Height = _buttonHeight;
            _backButton.Location = new Point(tmpParent.Width - _buttonWidth - _containerBorder,
                                             tmpParent.Height - _buttonHeight - _containerBorder);
            //_backButton.Location = new Point(ChoicesDisplayedPanel.Width - _buttonWidth - _containerBorder,
            //                                 ChoicesDisplayedPanel.Height - _buttonHeight - _containerBorder);
            _backButton.Click += new EventHandler(EventHandlers.BackToFactionButton.backFaction_Click);
            _backButton.BackColor = Color.White;
            tmpParent.Controls.Add(_backButton);

            Panel tmpSize = Styling.MainPageOutline.ChoicesDisplayedPanel;
            ContainerPanel.Location = new Point(_padding, _padding);
            ContainerPanel.Size = new Size(tmpSize.Width - 2 * _padding,
                                            tmpSize.Height - 3 * _padding);
            ContainerPanel.BackColor = Color.LightGray;
            ContainerPanel.AutoScroll = true;
            tmpParent.Controls.Add(ContainerPanel);

            // Second method

            //_displayPicHeight = ContainerPanel.Height;
            //_displayPicWidth = ContainerPanel.Width;
            int _yCoord = 0;
            int _totalWidth = 0;
            int _count = 1;
            int _rowCount = 1;
            if (_upgradeType == null)
            {
                foreach (DataRow _row in _dataTable.Rows)
                {

                    Panel _displayPanel = new Panel();
                    _displayPanel.Size = new Size(_choicePanelWidth, _choicePanelHeight);
                    _displayPanel.Location = new Point(_count * (_choicePanelWidth + _internalPadding) - _choicePanelWidth,
                                                       _yCoord + _internalPadding);
                    _displayPanel.BackColor = Color.Black;
                    ContainerPanel.Controls.Add(_displayPanel);

                    PictureBox _displayPic = new PictureBox();
                    _displayPic.Size = new Size(_choicePanelWidth - 2 * _choicePanelPaddingWidth,
                                                _choicePanelHeight - 2 * _choicePanelPaddingHeight - _labelHeight);
                    _displayPic.Location = new Point(_choicePanelPaddingWidth, _choicePanelPaddingHeight);
                    _displayPic.BackColor = Color.White;
                    _displayPic.Name = _row[0].ToString();
                    //_displayPic.Image = Image.FromFile("c:/Users/Burns/source/repos/Xwing/Xwing/Images/Pilots/royal_guard_pilot.png");
                    _displayPic.SizeMode = PictureBoxSizeMode.StretchImage;
                    _displayPanel.Controls.Add(_displayPic);

                    Label _displayLabel = new Label();
                    _displayLabel.Text = _row[0].ToString();
                    _displayLabel.Font = new Font("Arial", 8);
                    _displayLabel.TextAlign = ContentAlignment.MiddleCenter;
                    _displayLabel.Height = _labelHeight;
                    _displayLabel.BackColor = Color.White;
                    _displayLabel.Dock = DockStyle.Bottom;
                    _displayPanel.Controls.Add(_displayLabel);
                    _count += 1;
                    _totalWidth += _displayPanel.Width;

                    if (_totalWidth + _displayPanel.Width > tmpParent.Width)
                    {
                        _count = 1;
                        _yCoord = _rowCount * (_displayPanel.Height + 10);
                        _totalWidth = 0;
                        _rowCount += 1;
                    }

                    if (_type == "pilot")
                    {
                        string _loc = _row[8].ToString();
                        string _fileLocation = "c:/Users/Burns/source/repos/Xwing/Xwing/Images/";
                        _displayPic.Click += new EventHandler(EventHandlers.PilotChoicePic.pilot_Click);
                        //_displayPic.MouseHover += (sender, EventArgs) => { EventHandlers.MouseHoverImage.image_MouseHover(sender, EventArgs, ); };
                        _displayPic.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
                        _displayPic.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
                        //var _address = Methods.GetImageLocationString.GetLocation(_type, _displayPic.Name);
                        _displayPic.Image = Image.FromFile(_fileLocation + _loc);
                        //_displayPic.Image = Image.FromFile(_address);
                    }
                    else if (_type == "ship")
                    {
                        _displayPic.Click += new EventHandler(EventHandlers.ShipChoicePic.ship_Click);
                        _displayPic.Image = Image.FromFile(Methods.GetImageLocationString.GetLocation(_type, _displayPic.Name));
                    }
                    else if (_type == "upgradeTypes")
                    {

                        _displayPic.Click += new EventHandler(EventHandlers.UpgradeTypeChoicePic.upgradeType_Click);
                        var _address = Methods.GetImageLocationString.GetLocation(_type, _displayPic.Name);
                        _displayPic.Image = Image.FromFile(_address);
                    }
                    else if (_type == "upgrades")
                    {
                        bool _add = true;
                        _displayPic.Click += (sender, EventArgs) => { EventHandlers.UpgradeChoicePic.upgrade_Click(sender, EventArgs, _add); };
                        var _address = Methods.GetImageLocationString.GetLocation(_type, _displayPic.Name);
                        _displayPic.Image = Image.FromFile(_address);
                        _displayPic.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
                        _displayPic.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
                    }
                    _displayPicHeight = _displayPic.Height;
                    _displayPicWidth = _displayPic.Width;



                }
            }

            else
            {
                foreach (string _row in _upgradeType)
                {

                    Panel _displayPanel = new Panel();
                    _displayPanel.Size = new Size(_choicePanelWidth, _choicePanelHeight);
                    _displayPanel.Location = new Point(_count * (_choicePanelWidth + _internalPadding) - _choicePanelWidth,
                                                       _yCoord + _internalPadding);
                    _displayPanel.BackColor = Color.Black;
                    ContainerPanel.Controls.Add(_displayPanel);

                    PictureBox _displayPic = new PictureBox();
                    _displayPic.Size = new Size(_choicePanelWidth - 2 * _choicePanelPaddingWidth,
                                                _choicePanelHeight - 2 * _choicePanelPaddingHeight - _labelHeight);
                    _displayPic.Location = new Point(_choicePanelPaddingWidth, _choicePanelPaddingHeight);
                    _displayPic.BackColor = Color.White;
                    _displayPic.Name = _row;
                    //_displayPic.Image = Image.FromFile("c:/Users/Burns/source/repos/Xwing/Xwing/Images/Pilots/royal_guard_pilot.png");
                    //_displayPic.SizeMode = PictureBoxSizeMode.StretchImage;
                    _displayPic.SizeMode = PictureBoxSizeMode.Zoom;
                    //_displayPic.SizeMode = PictureBoxSizeMode.CenterImage;
                    _displayPanel.Controls.Add(_displayPic);

                    Label _displayLabel = new Label();
                    _displayLabel.Text = _row;
                    _displayLabel.Font = new Font("Arial", 8);
                    _displayLabel.TextAlign = ContentAlignment.MiddleCenter;
                    _displayLabel.Height = _labelHeight;
                    _displayLabel.BackColor = Color.White;
                    _displayLabel.Dock = DockStyle.Bottom;
                    _displayPanel.Controls.Add(_displayLabel);
                    _count += 1;
                    _totalWidth += _displayPanel.Width;

                    if (_totalWidth + _displayPanel.Width > tmpParent.Width)
                    {
                        _count = 1;
                        _yCoord = _rowCount * (_displayPanel.Height + 10);
                        _totalWidth = 0;
                        _rowCount += 1;
                    }

                    _displayPic.Click += new EventHandler(EventHandlers.UpgradeTypeChoicePic.upgradeType_Click);
                    var _address = Methods.GetImageLocationString.GetLocation(_type, _displayPic.Name);
                    _displayPic.Image = Image.FromFile(_address);

                    _displayPicHeight = _displayPic.Height;
                    _displayPicWidth = _displayPic.Width;



                }
            }
            

            Button _backToButton = new Button();
            _backToButton.Size = new Size(_backToButtonWidth, _backToButtonHeight);
            _backToButton.Location = new Point(0 + _internalPadding, tmpParent.Height - _backToButtonHeight - _internalPadding);
            //_backToButton.Location = new Point(ContainerPanel.Width - _backToButtonWidth,
            //                                   ContainerPanel.Height - _backToButtonHeight);
            _backToButton.BackColor = Color.LightBlue;

            

            if (_type == "pilot")
            {
                _backToButton.Text = _backToShipText;
                _backToButton.Click += new EventHandler(EventHandlers.BackToShipButton.backToShip_Click);
            }
            else if (_type == "upgradeTypes")
            {
                _backToButton.Text = _backToPilotText;
                _backToButton.Click += new EventHandler(EventHandlers.BackToPilotButton.backToPilot_Click);
            }
            else if (_type == "upgrades")
            {
                _backToButton.Text = _backToUpgradeCatsText;
                _backToButton.Click += new EventHandler(EventHandlers.BackToUpgradeTypesButton.backToUpgradeTypes_Click);
            }

            if (_type == "pilot" || _type == "upgradeTypes" || _type == "upgrades")
            {
                //ContainerPanel.Controls.Add(_backToButton);
                //tmpParent.Controls.Remove(_backToButton);
                tmpParent.Controls.Add(_backToButton);
            }

            if (_dataTable != null)
            {
                _dataTable.Clear();
                _dataTable.Columns.Clear();
            }

            
        }
    }
}
