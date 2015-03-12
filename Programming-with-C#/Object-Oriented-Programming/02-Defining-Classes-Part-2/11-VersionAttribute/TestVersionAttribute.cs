namespace VersionAttribute
{
    using System;

    using Helper;

    /// <summary>
    /// Problem 11. Version attribute
    /// Create a `[Version]` attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format `major.minor` (e.g. `2.11`).
    /// Apply the version attribute to a sample class and display its version at runtime.
    /// </summary>
    [VersionAttribute("1.01")]
    public class TestVersionAttribute
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            Type type = typeof(TestVersionAttribute);
            DisplayTypeAttributes(type);          
        }

        public static void DisplayTypeAttributes(Type type)
        {           
            object[] attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute);
            }   
        }
    }
}
