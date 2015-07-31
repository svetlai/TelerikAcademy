namespace Abstraction.Common
{
    using System;

    public static class Validator
    {
        private const string PositiveNumException = "{0} must be a positive number!";

        public static void ValidateRadius(double value, string property)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(PositiveNumException, property);
            }
        }
    }
}
