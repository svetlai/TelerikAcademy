namespace CookingVegetables
{
    using System;

    public class Cook
    {
        public static void Main()
        {
            var chef = new Chef();
            var bowl = chef.Cook();
            Console.WriteLine(bowl);
        }
    }
}
