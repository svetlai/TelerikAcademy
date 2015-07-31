namespace InheritanceAndPolymorphism.Common
{
    using System;

    public static class Validator
    {
        private const string NullObjectExceptionMsg = "{0} cannot be null.";
        private const string EmptyStringExceptionMsg = "{0} must not be left blank.";
        private const string StringLengthExceptionMsg = "{0} must be between {1} and {2}";
        private const string ExactStringLengthExceptionMsg = "{0} must be {1} symbols long.";
        private const string DigitsOnlyExceptionMsg = "{0} must contain digits only.";

        public static void ValidateNullObject(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(string.Format(NullObjectExceptionMsg, Type.GetType(obj.ToString()).Name));
            }
        }

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

        public static void ValidateExactStringLength(string value, string property, int length)
        {
            if (value.Length != length)
            {
                throw new ArgumentException(string.Format(ExactStringLengthExceptionMsg, property, length));
            }
        }

        public static void ValidateStringOfDigit(string value, string property)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    throw new ArgumentException(string.Format(DigitsOnlyExceptionMsg, property));
                }
            }
        }
    }
}
