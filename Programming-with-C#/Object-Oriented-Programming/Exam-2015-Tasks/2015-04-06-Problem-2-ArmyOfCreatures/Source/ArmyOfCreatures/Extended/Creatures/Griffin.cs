namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    /// <summary>
    /// The Griffin is a creature with attack 8, defense 8, damage 4.5 and health points 25. It also has the following specialties:
    /// DoubleDefenseWhenDefending for 5 rounds
    /// AddDefenseWhenSkip with 3 defense points
    /// Hate specialty to WolfRaider creatures
    /// </summary>
    public class Griffin : Creature
    {
        private const int GriffinAttackPoints = 8;
        private const int GriffinDefensePoints = 8;
        private const int GriffinHealthPoints = 25;
        private const decimal GriffinDamagePoints = 4.5m;

        public Griffin()
            : base(GriffinAttackPoints, GriffinDefensePoints, GriffinHealthPoints, GriffinDamagePoints)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
