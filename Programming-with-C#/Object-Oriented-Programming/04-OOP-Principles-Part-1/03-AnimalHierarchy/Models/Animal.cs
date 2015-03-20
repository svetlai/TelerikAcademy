namespace AnimalHierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalHierarchy.Contracts;

    public abstract class Animal : ISound
    {
        private const string NegativeAgeExceptionMsg = "Age cannot be negative.";
        private const string NameNullExceptionMsg = "Name cannot be empty.";

        private int age;
        private string name;

        protected Animal()
        {
        }

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeAgeExceptionMsg);
                }

                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                this.name = value;
            }
        }

        public Gender Gender { get; set; }

        public static double CalculateAverageAge(IEnumerable<Animal> animals) 
        {
            return animals.Average(a => a.Age);
        }

        public abstract string MakeSound();
    }
}
