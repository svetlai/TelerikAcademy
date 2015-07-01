namespace CookingVegetables
{
    using System;

    public class Chef
    {
        public void Cook()
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
            throw new NotImplementedException();
        }

        private static void Peel(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }
    }
}