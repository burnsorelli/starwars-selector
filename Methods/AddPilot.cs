using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class AddPilot
    {

        public static void Add(bool _add)
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            if (_add)
            {
                bool _canBeAdded = true;

                if(_pilot.UniquePilot == "Yes")
                {
                    foreach (NonStaticClasses.Pilots _tmpPilot in TrackerVariables.TrackedVariables.PilotList)
                    {
                        if(_tmpPilot.Name == _pilot.Name)
                        {
                            MessageBox.Show("You cannot add this unique pilot more than once");
                            _canBeAdded = false;
                            break;
                        }
                    }
                }
                if (_canBeAdded == true)
                {
                    TrackerVariables.TrackedVariables.PilotList.Add(_pilot);
                    Styling.HeaderSquadSelected.GetElements();
                    Methods.GetTotalScore.GetScore();
                    Styling.AddPilotPopup.ContainerPanel.Visible = false;
                }
                else
                {
                    // need to stop the add upgrades being displayed and instead reload the pilots
                    //Styling.MainPageChoices.GetElements()
                    //Styling.AddPilotPopup.ContainerPanel.Visible = false;
                }
            }
            else
            {
                foreach(var _tmpPilot in TrackerVariables.TrackedVariables.PilotList)
                {
                    if (_tmpPilot.UniqueId == _pilot.UniqueId)
                    {
                        TrackerVariables.TrackedVariables.PilotList.Remove(_tmpPilot);
                        Methods.GetTotalScore.GetScore();
                        //Styling.HeaderOutline.ChosenSquadPanel.Controls.Clear(); // NOT SURE THIS IS THE RIGHT ONE
                        Styling.HeaderSquadSelected.GetElements();
                        Styling.AddPilotPopup.ContainerPanel.Visible = false;
                        break;
                    }
                }
                Styling.MainPageChoices.ContainerPanel.Controls.Clear();
                Methods.PopulateShipChoices.GetShips();
            }
            Methods.ResetUniqueId.Reset();
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddPilotPopup.AddPilotButton);
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddPilotPopup.ChooseUpgradesButton);
        }
    }
}
