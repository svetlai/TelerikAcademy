namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore, IOrganism
    {
        private const int BoarSize = 4;
        private const int BoarBiteSize = 2;

        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, BoarSize)
        {
            this.biteSize = BoarBiteSize;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && this.Size >= animal.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
