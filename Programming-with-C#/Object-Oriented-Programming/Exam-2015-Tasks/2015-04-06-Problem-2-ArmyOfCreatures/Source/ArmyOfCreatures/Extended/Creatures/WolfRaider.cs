namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    /// <summary>
    /// The WolfRaider is a creature with attack 8, defense 5, health points 10, damage 3.5 and:
    /// DoubleDamage specialty for 7 rounds
    /// </summary>
    public class WolfRaider : Creature
    {
        private const int WolfRaiderAttackPoints = 8;
        private const int WolfRaiderDefensePoints = 5;
        private const int WolfRaiderHealthPoints = 10;
        private const decimal WolfRaiderDamagePoints = 3.5m;

        public WolfRaider()
            : base(WolfRaiderAttackPoints, WolfRaiderDefensePoints, WolfRaiderHealthPoints, WolfRaiderDamagePoints)
        {
            this.AddSpecialty(new DoubleDamage(7));
        }
    }
}
