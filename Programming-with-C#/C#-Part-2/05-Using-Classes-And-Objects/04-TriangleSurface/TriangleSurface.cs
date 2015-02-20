namespace TriangleSurface
{
    using System;

    /// <summary>
    /// Problem 4. Triangle surface
    /// Write methods that calculate the surface of a triangle by given:
    /// - Side and an altitude to it;
    /// - Three sides;
    /// - Two sides and an angle between them;
    /// Use `System.Math`.
    /// </summary>
    public class TriangleSurface
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Triangle surface \nWrite methods that calculate the surface of a triangle by given: \n- Side and an altitude to it; \n- Three sides; \n- Two sides and an angle between them; \nUse `System.Math`.\n");

            ProcessCommands();
        }

        public static double CalculateTriangleSurface(double side, double altitude)
        {
            if (side <= 0 || altitude <= 0)
            {
                throw new ArgumentException("Side and altitude must be positive numbers.");
            }

            return (side * altitude) / 2;
        }

        public static double CalculateTriangleSurface(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides must be positive numbers.");
            }


            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("This triangle is impossible. Please enter valid sides.");
            }

            // Heron's formula
            double semiPerimeter = (sideA + sideB + sideC) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        public static double CalculateTriangleSurface(double sideA, double sideB, decimal angle)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("Sides must be positive numbers.");
            }

            if (angle <= 0 || angle >= 180)
            {
                throw new ArgumentException("Angle must be in the range [1 - 179]");
            }

            return ((sideA * sideB) / 2) * Math.Sin((double)angle);
        }

        private static void ProcessCommands()
        {
            Console.WriteLine("Please choose a task: \nCalculate triangle surface by given: \n1. Side and altitude to it \n2. Three sides \n3. Two sides and an angle between them \n4. End");

            string command = Console.ReadLine();
            while (command != "4")
            {
                double area = 0;
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Calculate triangle surface by given side and altitude to it.");
                        Console.Write("Enter side: ");

                        double side;
                        if (!double.TryParse(Console.ReadLine(), out side))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        Console.Write("Enter altitude: ");
                        double altitude;
                        if (!double.TryParse(Console.ReadLine(), out altitude))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        area = CalculateTriangleSurface(side, altitude);
                        break;
                    case "2":
                        Console.WriteLine("Calculate triangle surface by given three sides");
                        Console.Write("Enter three sides separated by space: ");

                        double[] sides = ConvertStringOfIntsToArray(Console.ReadLine());

                        area = CalculateTriangleSurface(sides[0], sides[1], sides[2]);
                        break;
                    case "3":
                        Console.WriteLine("Calculate triangle surface by given two sides and an angle between them");
                        Console.Write("Enter side a: ");

                        double a;
                        if (!double.TryParse(Console.ReadLine(), out a))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        Console.Write("Enter side b: ");

                        double b;
                        if (!double.TryParse(Console.ReadLine(), out b))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        Console.Write("Enter angle (in degrees): ");

                        decimal angle;
                        if (!decimal.TryParse(Console.ReadLine(), out angle))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        area = CalculateTriangleSurface(a, b, angle);
                        break;
                }

                Console.WriteLine("Surface: {0}", area);
                Console.Write("Choose another task: ");
                command = Console.ReadLine();
            }
        }
        private static double[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), double.Parse);
        }
    }
}
