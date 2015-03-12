namespace GenericList
{
    using System;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 5. Generic class
    ///   Write a generic class `GenericList<T>` that keeps a list of elements of some parametric type `T`.
    ///   Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    ///   Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and `ToString()`.
    ///   Check all input parameters to avoid accessing elements at invalid positions.
    /// Problem 6. Auto-grow
    ///   Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    /// Problem 7. Min and Max
    ///   Create generic methods `Min<T>()` and `Max<T>()` for finding the minimal and maximal element in the `GenericList<T>`.
    ///   You may need to add a generic constraints for the type `T`.
    /// </summary>
    public class TestList
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestGenericList();
        }

        public static void TestGenericList()
        {
            StringBuilder sb = new StringBuilder();

            // Create instance
            GenericList<int> list = new GenericList<int>();

            sb.AppendLine("Playing with the Generic List class:")
                .AppendLine()
                .AppendFormat("Initial Count: {0}", list.Count)
                .AppendLine()
                .AppendFormat("Initial Capacity: {0}", list.Capacity)
                .AppendLine()
                .AppendLine(Constants.Border);

            // Add
            list.Add(1);
            list.Add(2);
            list.Add(3);

            sb.AppendFormat("Count after adding 3 elements: {0}", list.Count)
                .AppendLine()
                .AppendFormat("Capacity: {0}", list.Capacity)
                .AppendLine()
                .AppendLine(list.ToString())
                .AppendLine(Constants.Border);

            // RemoveAt
            list.RemoveAt(0);

            sb.AppendFormat("Count after removing the element at index 0: {0}", list.Count)
                .AppendLine()
                .AppendLine(list.ToString())
                .AppendLine(Constants.Border);

            // InsertAt
            list.InsertAt(1, 5);

            sb.AppendFormat("Count after inserting an element at index 1: {0}", list.Count)
                .AppendLine()
                .AppendLine(list.ToString())
                .AppendLine(Constants.Border);

            // Min, Max, this[]
            sb.AppendFormat("Min: {0}", list.Min())
                .AppendLine()
                .AppendFormat("Max: {0}", list.Max())
                .AppendLine()
            .AppendFormat("Element at index 2: {0}", list[2])
                .AppendLine()
                .AppendLine(Constants.Border);

            // Clear
            list.Clear();

            sb.AppendFormat("Count after clearing the list: {0}", list.Count)
                .AppendLine()
                .Append(Constants.Border);

            Console.WriteLine(sb.ToString());
        }
    }
}
