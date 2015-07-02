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

            try
            {
                var meal = CookingIf.ProcessVegetable(potato, chef);
                Console.WriteLine(meal);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
           
            MatrixIf.VisitCell(5, 5);
        }
    }
}
