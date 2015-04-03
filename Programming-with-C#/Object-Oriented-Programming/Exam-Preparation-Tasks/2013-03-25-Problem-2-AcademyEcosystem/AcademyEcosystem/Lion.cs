namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore, IOrganism
    {
        private const int LionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, LionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && this.Size * 2 >= animal.Size)
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
