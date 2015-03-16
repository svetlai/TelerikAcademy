namespace AnimalHierarchy.Models
{
    public class Cat : Animal
    {
        public Cat()
        {
        }

        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string MakeSound()
        {
            return "Meow!";
        }
    }
}
