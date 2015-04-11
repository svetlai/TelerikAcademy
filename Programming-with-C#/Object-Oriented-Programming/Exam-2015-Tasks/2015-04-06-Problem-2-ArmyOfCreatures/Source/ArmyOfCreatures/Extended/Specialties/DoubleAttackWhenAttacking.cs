namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private const int MinRounds = 0;

        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds <= MinRounds)
            {
                throw new ArgumentOutOfRangeException("rounds", string.Format(GlobalConstants.PositiveRoundsExcMsg, MinRounds));
            }

            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            this.rounds--;
            attackerWithSpecialty.CurrentAttack *= 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
