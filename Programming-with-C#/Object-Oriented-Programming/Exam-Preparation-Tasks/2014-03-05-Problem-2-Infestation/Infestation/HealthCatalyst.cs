namespace Infestation
{
    public class HealthCatalyst : Catalyst
    {
        public const int HealthCatalystHealthEffect = 3;

        public HealthCatalyst()
            : base(Supplement.ZeroEffect, HealthCatalystHealthEffect, Supplement.ZeroEffect)
        {
        }
    }
}
