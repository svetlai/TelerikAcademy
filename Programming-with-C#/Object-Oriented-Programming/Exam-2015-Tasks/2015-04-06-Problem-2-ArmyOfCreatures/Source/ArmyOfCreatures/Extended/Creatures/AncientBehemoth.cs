namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    /// <summary>
    /// The AncientBehemoth is a creature with attack 19, defense 19, damage 40, health points 300 and has the following specialties:
    /// ReduceEnemyDefenseByPercentage specialty with 80% damage reduction
    /// DoubleDefenseWhenDefending specialty for 5 rounds
    /// </summary>
    public class AncientBehemoth : Creature
    {
        private const int AncientBehemothAttackPoints = 19;
        private const int AncientBehemothDefensePoints = 19;
        private const int AncientBehemothHealthPoints = 300;
        private const decimal AncientBehemothDamagePoints = 40;

        public AncientBehemoth()
            : base(AncientBehemothAttackPoints, AncientBehemothDefensePoints, AncientBehemothHealthPoints, AncientBehemothDamagePoints)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
