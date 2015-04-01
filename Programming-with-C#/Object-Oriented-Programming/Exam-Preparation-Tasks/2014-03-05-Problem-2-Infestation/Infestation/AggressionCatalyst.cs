namespace Infestation
{
    public class AggressionCatalyst : Catalyst
    {
        public const int AggressionCatalystAggressionEffect = 3;

        public AggressionCatalyst()
            : base(Supplement.ZeroEffect, Supplement.ZeroEffect, AggressionCatalystAggressionEffect)
        {
        }
    }
}
