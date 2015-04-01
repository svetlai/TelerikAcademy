namespace Infestation
{
    public class Queen : Infestor
    {
        public const int QueenPower = 1;
        public const int QueenAggression = 1;
        public const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
        }
    }
}
