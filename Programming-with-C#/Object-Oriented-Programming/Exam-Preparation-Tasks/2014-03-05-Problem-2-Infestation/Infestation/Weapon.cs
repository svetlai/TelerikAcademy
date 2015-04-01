namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int WeaponAggressionEffect = 3;
        private const int WeaponPowerEffect = 10;

        public Weapon()
            : base(Supplement.ZeroEffect, Supplement.ZeroEffect, Supplement.ZeroEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = WeaponPowerEffect;
                this.AggressionEffect = WeaponAggressionEffect;
            }
        }
    }
}
