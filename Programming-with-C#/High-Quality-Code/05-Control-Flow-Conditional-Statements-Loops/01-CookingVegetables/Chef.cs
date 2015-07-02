namespace CookingVegetables
{
    using System;

    public class Chef
    {
        public Bowl Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);

            return bowl;
        }

        public Bowl Cook(Vegetable vegetable)
        {
            Bowl bowl = GetBowl();
            bowl.Add(vegetable);

            return bowl;
        }

        private static Bowl GetBowl()
        {
            return new Bowl();
        }

        private static Carrot GetCarrot()
        {
            return new Carrot();
        }

        private static Potato GetPotato()
        {
            return new Potato();
        }

        private static void Cut(Vegetable vegetable)
        {
            vegetable.IsCut = true;
        }

        private static void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }
    }
}