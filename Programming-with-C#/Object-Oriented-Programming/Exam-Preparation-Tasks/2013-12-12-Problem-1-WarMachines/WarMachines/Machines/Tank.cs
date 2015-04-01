namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double TankDefenceModeDefensePoints = 30;
        private const double TankDefenceModeAttackPoints = 40;
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, 100, attackPoints, defensePoints)
        {
            this.DefenseMode = true;
            this.DefensePoints += TankDefenceModeDefensePoints;
            this.AttackPoints -= TankDefenceModeAttackPoints;
        }

        public bool DefenseMode
        {
            get 
            {
                return this.defenseMode;
            }

            private set
            {
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.DefensePoints -= TankDefenceModeDefensePoints;
                this.AttackPoints += TankDefenceModeAttackPoints;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += TankDefenceModeDefensePoints;
                this.AttackPoints -= TankDefenceModeAttackPoints;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string defense = this.DefenseMode ? "ON" : "OFF";

            sb.Append(base.ToString())
                .Append(string.Format(" *Defense: {0}", defense));

            return sb.ToString();
        }
    }
}
