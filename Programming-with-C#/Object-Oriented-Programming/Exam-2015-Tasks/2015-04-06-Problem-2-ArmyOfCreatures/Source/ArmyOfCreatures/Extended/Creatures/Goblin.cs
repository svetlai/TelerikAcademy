namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;

    /// <summary>
    /// The Goblin is a creature with attack 4, defence 2, health points 5 and damage 1.5 and no specialties.
    /// </summary>
    public class Goblin : Creature
    {
        private const int GoblinAttackPoints = 4;
        private const int GoblinDefensePoints = 2;
        private const int GoblinHealthPoints = 5;
        private const decimal GoblinDamagePoints = 1.5m;

        public Goblin()
            : base(GoblinAttackPoints, GoblinDefensePoints, GoblinHealthPoints, GoblinDamagePoints)
        {
        }
    }
}
