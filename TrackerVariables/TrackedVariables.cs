using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.TrackerVariables
{
    class TrackedVariables
    {
        public static string FactionChosen;
        public static List<NonStaticClasses.Pilots> PilotList = new List<NonStaticClasses.Pilots>();
        public static NonStaticClasses.Pilots SelectedPilot = null;
        public static NonStaticClasses.Upgrades SelectedUpgrade = null;
        public static List<NonStaticClasses.Upgrades> CurrentListUpgrades = new List<NonStaticClasses.Upgrades>();
        public static int UniqueID = 1;
        public static int MaxPoints = 100;
    }
}
