namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int InfestationSporesAggressionEffect = 20;
        private const int InfestationSporesPowerEffect = -1;

        public InfestationSpores()
            : base(InfestationSporesPowerEffect, Supplement.ZeroEffect, InfestationSporesAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.AggressionEffect = Supplement.ZeroEffect;
                this.PowerEffect = Supplement.ZeroEffect;
            }
        }
    }
}
