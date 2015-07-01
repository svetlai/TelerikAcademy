namespace IfStatements
{
    using System;

    using CookingVegetables;

    public class TestIfs
    {
        public static void Main(string[] args)
        {
            var potato = new Potato();
            var chef = new Chef();
            var meal = CookingIf.ProcessVegetable(potato, chef);
            Console.WriteLine(meal);

            MatrixIf.VisitCell(5, 5);
        }
    }
}
