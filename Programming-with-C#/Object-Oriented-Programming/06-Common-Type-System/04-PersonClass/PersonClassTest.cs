namespace PersonClass
{
    using System;

    using Helper;

    public class PersonClassTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestPerson();
        }

        private static void TestPerson()
        {
            var pesho = new Person("Pesho");
            var gosho = new Person("Gosho", 15);

            Console.WriteLine(pesho.ToString());
            Console.WriteLine(gosho.ToString());
        }
    }
}
