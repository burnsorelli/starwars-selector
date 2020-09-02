using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class AddPilotPopup
    {
        public static Panel ContainerPanel = new Panel();
        private static int _containerPanelWidth = 400;
        private static int _containerPanelHeight = 210;
        public static int PaddingLeft = 5; // Does this need to be public
        public static int PaddingTop = 5; // does this need to be public
        private static int _containerBorder = 3;


        public static Button AddPilotButton = new Button(); // does this need to be public
        private static int _buttonHeight = 40;
        private static int _buttonWidth = 75;
        private static int _buttonPadding = 10;

        public static Button ChooseUpgradesButton = new Button(); // does this need to be public
        private static String _chooseUpgradesButtonText = "Choose Upgrades";

        private static Button CloseButton = new Button();
        private static String _closeButtonText = "Close";

        private static Panel _pilotPanel = new Panel();
        private static int _pilotPanelWidth = 100;
        private static int _pilotPanelHeight = 150;
        private static int _detailsLabelWidth = 200;
        private static int _detailsLabelHeight = _pilotPanelHeight;

        public static PictureBox PilotPicture = new PictureBox();  // does this need to be public

        private static Label PilotName = new Label();

        //private static Label PilotDetails = new Label();
        private static TextBox PilotDetails = new TextBox();

        public static void GetElements(bool _add)
        {

            
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            ContainerPanel.Size = new Size(_containerPanelWidth, _containerPanelHeight);
            Tuple<int, int> _location = Methods.GetPopupLocation.GetLocation(ContainerPanel);
            ContainerPanel.Location = new Point(_location.Item1, _location.Item2);
            ContainerPanel.BackColor = Color.LightBlue;
            ContainerPanel.Paint += (sender, EventArgs) => { PaintEventHandlers.DrawBorder.Draw(sender, EventArgs, ContainerPanel, _containerBorder); };
            Styling.WholeForm.TheForm.Controls.Add(ContainerPanel);


            _pilotPanel.Size = new Size(_pilotPanelWidth, _pilotPanelHeight);
            _pilotPanel.Location = new Point(PaddingLeft, PaddingTop);
            _pilotPanel.BackColor = Color.Black;
            ContainerPanel.Controls.Add(_pilotPanel);

            PilotPicture.Location = new Point(0, 0);
            PilotPicture.Size = new Size(_pilotPanelWidth, _pilotPanelHeight - PilotName.Height); // used before sized
            PilotPicture.BackColor = Color.CadetBlue;
            PilotPicture.Image = Image.FromFile(_pilot.PilotPicLocation);
            PilotPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            PilotPicture.MouseHover += new EventHandler(EventHandlers.MouseHoverImage.image_MouseHover);
            PilotPicture.MouseLeave += new EventHandler(EventHandlers.MouseHoverImage.image_MouseLeave);
            _pilotPanel.Controls.Add(PilotPicture);

            PilotName.Location = new Point(0, PilotPicture.Height);
            PilotName.Text = _pilot.Name;
            PilotName.BackColor = Color.White;
            _pilotPanel.Controls.Add(PilotName);

            PilotDetails.Location = new Point(_pilotPanel.Location.X + _pilotPanelWidth + _buttonPadding,
                                              _pilotPanel.Location.Y);
            PilotDetails.Text = Methods.GetPilotDetailsString.GetDetails();
            PilotDetails.Size = new Size(_detailsLabelWidth, _detailsLabelHeight);
            PilotDetails.BackColor = Color.White;
            PilotDetails.Multiline = true;
            PilotDetails.ReadOnly = true;
            PilotDetails.SelectionStart = 0;
            //PilotDetails.Enabled = false;
            PilotDetails.ScrollBars = ScrollBars.Vertical;
            PilotDetails.Font = new Font("Arial", 9);
            ContainerPanel.Controls.Add(PilotDetails);

            Panel _upgradePanel = Styling.PilotSelectedUpgrade.ContainerPanel; // needs to refer to the new styling not written yet
            var _height = _pilotPanel.Location.Y + _pilotPanelHeight + _containerBorder;
            
            Styling.PilotSelectedUpgrade.GetElements(_height);

            AddPilotButton.Location = new Point(_pilotPanel.Location.X,
                                                _pilotPanel.Location.Y + _pilotPanelHeight + 2* _containerBorder + _upgradePanel.Height);
            AddPilotButton.Size = new Size(_buttonWidth, _buttonHeight);
            AddPilotButton.BackColor = Color.AliceBlue;
            if (_add)
            {
                AddPilotButton.Text = "Add pilot";
            }
            else
            {
                AddPilotButton.Text = "Remove pilot";
            }
            
            AddPilotButton.Click += (sender, EventArgs) => { EventHandlers.AddPilotButton.addPilot_Click(sender, EventArgs, _add); };
            ContainerPanel.Controls.Add(AddPilotButton);

            ChooseUpgradesButton.Location = new Point(_pilotPanel.Location.X + (_buttonWidth + _buttonPadding),
                                                      _pilotPanel.Location.Y + _pilotPanelHeight + 2 * _containerBorder + _upgradePanel.Height);
            ChooseUpgradesButton.Size = new Size(_buttonWidth, _buttonHeight);
            ChooseUpgradesButton.Text = _chooseUpgradesButtonText;
            
            ChooseUpgradesButton.Click += (sender, EventArgs) => { EventHandlers.ChooseUpgradesButton.chooseUpgradesButton_Click(sender, EventArgs, _add); };
            ContainerPanel.Controls.Add(ChooseUpgradesButton);

            CloseButton.Location = new Point(_pilotPanel.Location.X + 2 * (_buttonWidth + _buttonPadding),
                                             _pilotPanel.Location.Y + _pilotPanelHeight + 2 * _containerBorder + _upgradePanel.Height);
            CloseButton.Size = new Size(_buttonWidth, _buttonHeight);
            CloseButton.Text = _closeButtonText;
            CloseButton.Click += new EventHandler(EventHandlers.ClosePilotPopup.closeButton_Click);
            ContainerPanel.Controls.Add(CloseButton);

            ContainerPanel.BringToFront();
            ContainerPanel.Visible = true;

            Methods.ControlsActive.DisableControls(ContainerPanel);
        }
    }
}
