namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    /// <summary>
    /// Add class CyclopsKing. The CyclopsKing is a creature with attack 17, defense 13, damage 18, health points 70 and the following specialties:
    /// AddAttackWhenSkip with 3 attack points for each skip action.
    /// DoubleAttackWhenAttacking for 4 rounds
    /// DoubleDamage for 1 round
    /// </summary>
    public class CyclopsKing : Creature
    {
        private const int CyclopsKingAttackPoints = 17;
        private const int CyclopsKingDefensePoints = 13;
        private const int CyclopsKingHealthPoints = 70;
        private const decimal CyclopsKingDamagePoints = 18;

        public CyclopsKing()
            : base(CyclopsKingAttackPoints, CyclopsKingDefensePoints, CyclopsKingHealthPoints, CyclopsKingDamagePoints)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
