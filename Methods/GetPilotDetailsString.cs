using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.Methods
{
    class GetPilotDetailsString
    {
        private static string _pilotDetails = "";

        public static string GetDetails()
        {
            var pilot = TrackerVariables.TrackedVariables.SelectedPilot;
            _pilotDetails = "";
            _pilotDetails += "Name: " + pilot.Name +
                "\r\nDescription: " + pilot.Description +
                "\r\nPoints: " + pilot.Points +
                "\r\nPilot Skill: " + pilot.PilotSkill +
                "\r\nAttack: " + pilot.Attack +
                "\r\nAgility: " + pilot.Agility +
                "\r\nHull: " + pilot.Hull +
                "\r\nShield: " + pilot.Shield +
                "\r\nShip: " + pilot.Ship;
            return _pilotDetails;
        }
    }
}
