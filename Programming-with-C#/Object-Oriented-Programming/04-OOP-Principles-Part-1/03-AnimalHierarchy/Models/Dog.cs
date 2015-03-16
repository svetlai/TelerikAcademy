namespace AnimalHierarchy.Models
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string MakeSound()
        {
            return "Bau!";
        }
    }
}
