namespace Methods
{
    using System;

    using Methods.HelperMethods;
    using Methods.Models;

    public class MethodsEntry
    {
        public static void Main()
        {
            TestMethods();
            TestStudent();
        }

        public static void TestMethods() 
        { 
            Console.WriteLine(MathHelper.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(MathHelper.ConvertDigitToString(5));
            Console.WriteLine(MathHelper.FindMaxInt(5, -1, 3, 2, 14, 2, 3));
            
            Printer.PrintAsNumber(1.3, "f");
            Printer.PrintAsNumber(0.75, "%");
            Printer.PrintAsNumber(2.30, "r");

            Point firstPoint = new Point(3, -1);
            Point secondPoint = new Point(3, 2.5);

            Console.WriteLine(PointHelper.CalculateDistance(firstPoint, secondPoint));

            bool horizontal = PointHelper.FindDistanceType(firstPoint, secondPoint) == DistanceType.Horizontal;
            bool vertical = PointHelper.FindDistanceType(firstPoint, secondPoint) == DistanceType.Vertical;

            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);
        }

        public static void TestStudent() 
        { 
            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov"
            };

            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() 
            { 
                FirstName = "Stella", 
                LastName = "Markova" 
            };

            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
