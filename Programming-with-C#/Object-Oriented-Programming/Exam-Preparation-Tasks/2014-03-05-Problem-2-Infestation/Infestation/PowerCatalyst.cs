namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PowerCatalyst : Catalyst
    {
        public const int PowerCatalystPowerEffect = 3;

        public PowerCatalyst()
            : base(PowerCatalystPowerEffect, Supplement.ZeroEffect, Supplement.ZeroEffect)
        {
        }
    }
}
