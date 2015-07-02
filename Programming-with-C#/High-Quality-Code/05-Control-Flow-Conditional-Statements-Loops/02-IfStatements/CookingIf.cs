namespace IfStatements
{
    using System;

    using CookingVegetables;

    public class CookingIf
    {
        public static Bowl ProcessVegetable(Vegetable vegetable, Chef chef)
        {
            bool isCookable = IsCookable(vegetable);

            if (isCookable)
            {
                return chef.Cook(vegetable);
            }
            else
            {
                throw new ArgumentException("The vegetable must be peeled and not rotten in order to be cooked.");
            }
        }

        private static bool IsCookable(Vegetable vegetable)
        {
            if (vegetable != null && vegetable.IsPeeled && vegetable.IsNotRotten)
            {
                return true;
            }

            return false;
        }
    }
}
