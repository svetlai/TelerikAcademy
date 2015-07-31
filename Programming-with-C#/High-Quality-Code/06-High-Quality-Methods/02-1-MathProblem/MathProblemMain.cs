namespace MathProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MathProblemMain
    {
        public static void Main()
        {
            string[] numbers = HelperMethods.ReadInput();
            MathProblemSolution.Solve(numbers);
        }
    }
}