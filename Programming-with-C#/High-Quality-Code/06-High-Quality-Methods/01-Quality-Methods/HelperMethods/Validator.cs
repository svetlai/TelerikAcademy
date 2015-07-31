namespace Methods.HelperMethods
{
    using System;

    public static class Validator
    {
        private const string EmptyStringExceptionMsg = "{0} must not be left blank.";
        private const string StringLengthExceptionMsg = "{0} must be between {1} and {2}";

        public static void ValidateEmptyString(string value, string property)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(EmptyStringExceptionMsg, property));
            }
        }

        public static void ValidateStringLengthRange(string value, string property, int min, int max)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(string.Format(StringLengthExceptionMsg, property, min, max));
            }
        }
    }
}
