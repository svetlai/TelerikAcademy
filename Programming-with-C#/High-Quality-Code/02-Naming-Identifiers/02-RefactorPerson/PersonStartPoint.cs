namespace RefactorPerson
{
    using System;

    public class PersonStartPoint
    {
        public static void Main()
        {
            Console.WriteLine("Please enter an integer number");
            int id = int.Parse(Console.ReadLine());
            Person person = CreatePerson(id);
            Console.WriteLine(person.Gender);
        }

        public static Person CreatePerson(int id)
        {
            Person person = new Person();
            person.Id = id;

            if (id % 2 == 0)
            {
                person.Name = "Bro";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Chick";
                person.Gender = Gender.Female;
            }

            return person;
        }
    }
}
