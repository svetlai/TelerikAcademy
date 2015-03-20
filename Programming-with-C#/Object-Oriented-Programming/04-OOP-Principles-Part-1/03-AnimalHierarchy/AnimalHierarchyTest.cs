namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AnimalHierarchy.Models;
    using Helper;

    /// <summary>
    /// Problem 3. Animal hierarchy
    /// Create a hierarchy `Dog`, `Frog`, `Cat`, `Kitten`, `Tomcat` and define useful constructors and methods. Dogs, frogs and cats are `Animals`. All animals can produce sound (specified by the `ISound` interface). Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
    /// Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
    /// </summary>
    public class AnimalHierarchyTest
    {
        private static IRandomGenerator randomGenerator;
        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            randomGenerator = new RandomGenerator();

            var cats = CreateRandomAnimalsCollection<Cat>(10);
            var dogs = CreateRandomAnimalsCollection<Dog>(10);
            var frogs = CreateRandomAnimalsCollection<Frog>(10);
            var kittens = CreateRandomCatsCollection<Kitten>(10);
            var tomcats = CreateRandomCatsCollection<Tomcat>(10);

            double catsAverageAge = Animal.CalculateAverageAge(cats);
            double dogsAverageAge = Animal.CalculateAverageAge(dogs);
            double frogsAverageAge = Animal.CalculateAverageAge(frogs);
            double kittensAverageAge = Animal.CalculateAverageAge(kittens);
            double tomcatsAverageAge = Animal.CalculateAverageAge(tomcats);

            sb.AppendLine("Cats average age: " + catsAverageAge)
                .AppendLine("Dogs average age: " + dogsAverageAge)
                .AppendLine("Frogs average age: " + frogsAverageAge)
                .AppendLine("Kittens average age: " + kittensAverageAge)
                .AppendLine("Tomcats average age: " + tomcatsAverageAge);

            Console.WriteLine(sb);
        }

        public static ICollection<T> CreateRandomAnimalsCollection<T>(int count) where T : Animal
        {
            var animals = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var name = randomGenerator.RandomString(3, 10);
                var age = randomGenerator.RandomNumber(1, 10);
                Gender gender = (Gender)randomGenerator.RandomNumber(0, 2);
                object[] initializationParameters = new object[] { name, age, gender };
                var animal = (T)Activator.CreateInstance(typeof(T), initializationParameters);
                animals.Add(animal);
            }

            return animals;
        }

        public static ICollection<T> CreateRandomCatsCollection<T>(int count) where T : Cat
        {
            var animals = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var name = randomGenerator.RandomString(3, 10);
                var age = randomGenerator.RandomNumber(1, 10);
                object[] initializationParameters = new object[] { name, age };
                var animal = (T)Activator.CreateInstance(typeof(T), initializationParameters);
                animals.Add(animal);
            }

            return animals;
        }
    }
}
