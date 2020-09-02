using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xwing.NonStaticClasses
{
    class Upgrades
    {
        public static List<Upgrades> currentListUpgrades = new List<Upgrades>();
        public static Upgrades UpgradeSelected = null;

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public string Restrictions { get; set; }
        public string FactionRestriction { get; set; }
        public string ShipRestriction { get; set; }
        public string SizeRestriction { get; set; }
        public string UniqueUpgrade { get; set; }
        public int MinPilotLvl { get; set; }
        public int PilotSkill { get; set; }
        public int Attack { get; set; }
        public int Agility { get; set; }
        public int Hull { get; set; }
        public int Shield { get; set; }
        public int Modifications { get; set; }
        public int Elite { get; set; }
        public int Energy { get; set; }
        public int Crew { get; set; }
        public int Teams { get; set; }
        public int Cannons { get; set; }
        public int Torpedoes { get; set; }
        public int Missiles { get; set; }
        public int Illicit { get; set; }
        public int Systems { get; set; }
        public int Bombs { get; set; }
        public int Cargo { get; set; }
        public int Salvaged_Astromech { get; set; }
        public int Title { get; set; }
        public string Dual_Card { get; set; }
        public int Max_Mod_Pts { get; set; }
        public string UpgradePicLocation { get; set; }
        public Upgrades(int _id, string _type, string _name, string _description,  int _points, string _restrictions, 
            string _factionRestriction, string _shipRestriction, string _sizeRestriction, string _uniqueUpgrade, int _minPilotLvl,
             int _pilotSkill, int _attack, int _agility, int _hull, int _shield, int _modifications, int _elite, int _energy, 
             int _crew, int _teams, int _cannons, int _torpedoes, int _missiles, int _illicit, int _systems, int _bombs, int _cargo, int _salvagedAstromech,
             int _title, string _dualCard, int _max_Mod_Pts)
        {
            this.Id = _id;
            this.Name = _name;
            this.Description = _description;
            this.Type = _type;
            this.Points = _points;
            this.Restrictions = _restrictions;
            this.FactionRestriction = _factionRestriction;
            this.ShipRestriction = _shipRestriction;
            this.SizeRestriction = _sizeRestriction;
            this.UniqueUpgrade = _uniqueUpgrade;
            this.MinPilotLvl = _minPilotLvl;
            this.PilotSkill = _pilotSkill;
            this.Attack = _attack;
            this.Agility = _agility;
            this.Hull = _hull;
            this.Shield = _shield;
            this.Modifications = _modifications;
            this.Elite = _elite;
            this.Energy = _energy;
            this.Crew = _crew;
            this.Teams = _teams;
            this.Cannons = _cannons;
            this.Torpedoes = _torpedoes;
            this.Missiles = _missiles;
            this.Illicit = _illicit;
            this.Systems = _systems;
            this.Bombs = _bombs;
            this.Cargo = _cargo;
            this.Salvaged_Astromech = _salvagedAstromech;
            this.Title = _title;
            this.Dual_Card = _dualCard;
            this.Max_Mod_Pts = _max_Mod_Pts;
            this.UpgradePicLocation = Methods.GetImageLocationString.GetLocation("upgrades", Name);

            Methods.GetTotalScore.GetScore();
            
        }

    }
}
