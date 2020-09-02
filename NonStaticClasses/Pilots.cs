using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.NonStaticClasses
{
    class Pilots
    {
        public static List<Pilots> PilotList = new List<Pilots>();
        public static Pilots pilotSelected = null;
        //public static int _UniqueID = 1;
        //public static int UniqueID = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int PilotSkill { get; set; }
        public int Attack { get; set; }
        public int Agility { get; set; }
        public int Hull { get; set; }
        public int Shield { get; set; }
        public string UniquePilot { get; set; }
        public List<Upgrades> Upgrades = new List<Upgrades>();
        public int UniqueId { get; set; }
        public string Ship { get; set; }
        public string Faction { get; set; }
        public string Size { get; set; }
        public Dictionary<String, int> UpgradeTypeQty = new Dictionary<string, int>();
        public string PilotPicLocation { get; set; }
        public string ShipPicLocation { get; set; }
        public int Pilot_Id { get; set; }
        public string Ship_Type { get; set; }
        public bool Boost { get; set; }
        public int Max_Mod_Pts { get; set; }

        //public Pilots(string name, string description, int points, int pilotSkill, int attack, int agility, int hull, int shield, string uniquePilot, int _uniqueId, string _ship, string _faction, string _size)
        public Pilots(string name, string description, int points, int pilotSkill, int attack, int agility, int hull, int shield, string uniquePilot,
            string _ship, string _faction, string _size, int _pilot_Id, string _shipType, bool _boost)
        {
            this.Name = name;
            this.Description = description;
            this.Points = points;
            this.PilotSkill = pilotSkill;
            this.Attack = attack;
            this.Agility = agility;
            this.Hull = hull;
            this.Shield = shield;
            this.UniquePilot = uniquePilot;
            this.UniqueId = TrackerVariables.TrackedVariables.UniqueID;
            //this.UniqueId = _uniqueId;
            this.Ship = _ship;
            this.Faction = _faction;
            this.Size = _size;
            this.PilotPicLocation = Methods.GetImageLocationString.GetLocation("pilot", Name, Faction, Ship );
            this.ShipPicLocation = Methods.GetImageLocationString.GetLocation("ship", Ship);
            this.Pilot_Id = _pilot_Id;
            this.Ship_Type = _shipType;
            this.Boost = _boost;
            this.Max_Mod_Pts = 10;
            TrackerVariables.TrackedVariables.UniqueID += 1;
            //UniqueID += 1;
            //PilotList.Add(this); // THIS AUTOMATICALLY ADDS THE PILOT TO THE CURRENT LIST
            //MainPage.MainPageHeaderPanel.SquadSelectedPanel.SquadSelectedInternalPanelStyling.GetElements(); // CALLS STYLING WHEN AND ADDS PILOT - BAD!!!!!!
            // do i need to clear the container panel here before add new pilots?
            // Recalulate total score
            //MainPage.MainPageHeaderPanel.TotalScorePanel.CalcTotalScore.CalculateTotalScore();
        }

    }
}
