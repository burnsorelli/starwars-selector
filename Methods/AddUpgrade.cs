using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class AddUpgrade
    {
        public static void Add()
        {
            var _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            var _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;
            bool _alreadyUsed = Methods.CheckUniqueUpgrade.CheckUnique();
            bool _typeFilled = Methods.CheckUpgradeTypeFilled.CheckFilled();

            if(!_alreadyUsed && !_typeFilled)
            {
                _pilot.Upgrades.Add(_upgrade);
            }

            _pilot.PilotSkill += _upgrade.PilotSkill;
            _pilot.Attack += _upgrade.Attack;
            _pilot.Agility += _upgrade.Agility;
            _pilot.Hull += _upgrade.Hull;
            _pilot.Shield += _upgrade.Shield;
            _pilot.UpgradeTypeQty["Modification"] += _upgrade.Modifications;
            if (_pilot.UpgradeTypeQty.ContainsKey("Elite"))
            {
                _pilot.UpgradeTypeQty["Elite"] += _upgrade.Elite;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Energy"))
            {
                _pilot.UpgradeTypeQty["Energy"] += _upgrade.Energy;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Crew"))
            {
                _pilot.UpgradeTypeQty["Crew"] += _upgrade.Crew;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Teams"))
            {
                _pilot.UpgradeTypeQty["Teams"] += _upgrade.Teams;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Cannons"))
            {
                _pilot.UpgradeTypeQty["Cannons"] += _upgrade.Cannons;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Torpedoes"))
            {
                _pilot.UpgradeTypeQty["Torpedoes"] += _upgrade.Torpedoes;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Missiles"))
            {
                _pilot.UpgradeTypeQty["Missiles"] += _upgrade.Missiles;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Illicit"))
            {
                _pilot.UpgradeTypeQty["Illicit"] += _upgrade.Illicit;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Systems"))
            {
                _pilot.UpgradeTypeQty["Systems"] += _upgrade.Systems;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Bombs"))
            {
                _pilot.UpgradeTypeQty["Bombs"] += _upgrade.Bombs;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Cargo"))
            {
                _pilot.UpgradeTypeQty["Cargo"] += _upgrade.Cargo;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Salvage_Astromech"))
            {
                _pilot.UpgradeTypeQty["Salvaged_Astromech"] += _upgrade.Salvaged_Astromech;
            }
            if (_pilot.UpgradeTypeQty.ContainsKey("Title"))
            {
                _pilot.UpgradeTypeQty["Title"] += _upgrade.Title;
            }
            if(_upgrade.Max_Mod_Pts > 0)
            {
                _pilot.Max_Mod_Pts = _upgrade.Max_Mod_Pts;
            }

            //// FOR TESTING PURPOSES
            //string _output = "";
            //foreach (NonStaticClasses.Pilots _tmpPilot in TrackerVariables.TrackedVariables.PilotList)
            //{
            //    if(_pilot.Upgrades.Count > 0)
            //    {
            //        foreach(NonStaticClasses.Upgrades _tmpUpgrade in _tmpPilot.Upgrades)
            //        {
            //            _output += _tmpPilot.Name + " with uniqueID=" + _tmpPilot.UniqueId + " has " + _tmpUpgrade.Name + " upgrade\n";
            //        }
            //    }
            //}
            //MessageBox.Show(_output);

            Styling.AddUpgradePopup.ContainerPanel.Visible = false;
            Methods.GetTotalScore.GetScore();
            Styling.HeaderOutline.ChosenSquadPanel.Controls.Clear();
            Styling.HeaderSquadSelected.GetElements();
            Methods.RemoveEventHandlers.RemoveAllHandlers(Styling.AddUpgradePopup.AddUpgradeButton);
        }
    }
}
