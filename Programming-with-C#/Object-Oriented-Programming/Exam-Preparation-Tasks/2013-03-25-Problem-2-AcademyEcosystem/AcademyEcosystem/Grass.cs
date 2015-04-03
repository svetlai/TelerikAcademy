namespace AcademyEcosystem
{
    public class Grass : Plant, IOrganism
    {
        private const int PlantSize = 2;

        public Grass(Point location)
            : base(location, PlantSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}
