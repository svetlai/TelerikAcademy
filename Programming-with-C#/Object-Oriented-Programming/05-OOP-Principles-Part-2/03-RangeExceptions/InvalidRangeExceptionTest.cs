namespace RangeExceptions
{
    using System;

    using Helper;

    public class InvalidRangeExceptionTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            try
            {
                throw new InvalidRangeException<int>(2, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                throw new InvalidRangeException<DateTime>(DateTime.Now, DateTime.Now.AddDays(5));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
