namespace BitArray
{
    using System;
    using System.Text;

    using Helper;

    public class BitArray64Test
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestBitArray64();
        }

        private static void TestBitArray64()
        {
            var sb = new StringBuilder();

            var bitArray = new BitArray64(28);
            sb.AppendLine("Number: 28");

            sb.Append("Indexer: ");
            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                sb.Append(bitArray[i]);
            }

            sb.Append("\nForeach: ");
            Console.Write(sb);
            sb.Clear();

            foreach (var bit in bitArray)
            {
                sb.Insert(0, bit);
            }

            var anotherbitArray = new BitArray64(30);

            sb.AppendLine()
                .AppendLine("\nAnother number: 30")
                .AppendFormat("Equals: {0}", bitArray.Equals(anotherbitArray))
                .AppendLine()
                .AppendFormat("== {0}", bitArray == anotherbitArray)
                .AppendLine()
                .AppendFormat("!= {0}", bitArray != anotherbitArray);

            Console.WriteLine(sb);
        }
    }
}
