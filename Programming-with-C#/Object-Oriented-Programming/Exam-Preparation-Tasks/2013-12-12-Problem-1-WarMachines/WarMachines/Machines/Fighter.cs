namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode)
            : base(name, 200, attackPoints, defencePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }

            private set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string defense = this.StealthMode ? "ON" : "OFF";

            sb.Append(base.ToString())
                .Append(string.Format(" *Stealth: {0}", defense));

            return sb.ToString();
        }
    }
}
