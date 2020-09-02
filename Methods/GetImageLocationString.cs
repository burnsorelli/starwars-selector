using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.Methods
{
    class GetImageLocationString
    {
        public static string GetLocation(string _type, string _name)
        {
            string _fileLocation = "c:/Users/Burns/source/repos/Xwing/Xwing/Images/";
            string _ext = ".png";
            string _pictureLocation = "";
            string _fileName = "";
            NonStaticClasses.Pilots _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            NonStaticClasses.Upgrades _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;

            if (_type == "ship")
            {
                _fileName = "Ships/" + _name.ToLower().Replace(' ', '_').Replace('-', '_').Replace('/','_') + _ext;
            }
            else if (_type == "pilot")
            {
                _fileName = "Pilots/" + _name.ToLower().Replace(' ', '_').Replace("'", "").Replace("-", "_").Replace("(", "").Replace(")","") + _ext;
                //_fileName.Replace("'", "");
            }
            else if (_type == "upgrades")
            {
                _fileName = "Upgrades/" + _name.ToLower().Replace(' ', '_').Replace('-', '_').Replace('/', '_').Replace("(", "").Replace(")", "").Replace("'","").Replace(".","") + _ext;
            }
            else if (_type == "upgradeTypes")
            {
                _fileName = "UpgradeTypes/" + _name.ToLower().Replace(' ', '_') + _ext;
            }
            _pictureLocation = _fileLocation + _fileName;

            return _pictureLocation;
        }
        public static string GetLocation(string _type, string _name, string _faction, string _ship)
        {
            string _fileLocation = "c:/Users/Burns/source/repos/Xwing/Xwing/Images/";
            string _ext = ".png";
            string _pictureLocation = "";
            string _fileName = "";
            NonStaticClasses.Pilots _pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            NonStaticClasses.Upgrades _upgrade = TrackerVariables.TrackedVariables.SelectedUpgrade;

            if (_type == "ship")
            {
                _fileName = "Ships/" + _name.ToLower().Replace(' ', '_').Replace('-', '_').Replace('/', '_') + _ext;
            }
            else if (_type == "pilot")
            {
                string _fullName = _name + "_" + _ship + "_" + _faction;
                _fileName = "Pilots/" + _fullName.ToLower().Replace(' ', '_').Replace("'", "").Replace("-", "_").Replace("(", "").Replace(")", "").Replace("/","_") + _ext;
                //_fileName = "Pilots/" + _name.ToLower().Replace(' ', '_').Replace("'", "").Replace("-", "_").Replace("(", "").Replace(")", "") + _ext;
                //_fileName.Replace("'", "");
            }
            else if (_type == "upgrades")
            {
                _fileName = "Upgrades/" + _name.ToLower().Replace(' ', '_').Replace('-', '_').Replace('/', '_').Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "") + _ext;
            }
            else if (_type == "upgradeTypes")
            {
                _fileName = "UpgradeTypes/" + _name.ToLower().Replace(' ', '_') + _ext;
            }
            _pictureLocation = _fileLocation + _fileName;

            return _pictureLocation;
        }
    }
}
