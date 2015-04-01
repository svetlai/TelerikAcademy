namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        public const int ZeroEffect = 0;

        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect
        {
            get 
            {
                return this.powerEffect;
            }

            protected set
            {
                this.powerEffect = value;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }

            protected set
            {
                this.healthEffect = value;
            }
        }

        public int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;
            }

            protected set
            {
                this.aggressionEffect = value;
            }
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
