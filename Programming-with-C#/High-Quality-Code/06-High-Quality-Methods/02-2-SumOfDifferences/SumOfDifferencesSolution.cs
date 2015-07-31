namespace SumOfDifferences
{
    using System;
    using System.Collections.Generic;

    public class SumOfDifferencesSolution
    {
        public static decimal Solve(string input)
        {
            decimal[] sequence = HelperMethods.ConvertStringOfIntsToArray(input);
            IList<decimal> allDifferences = GetOddAbsoluteDifferences(sequence);
            decimal sum = FindOddAbsoluteDifferenceSum(allDifferences);

            return sum;
        }

        private static decimal FindOddAbsoluteDifferenceSum(IList<decimal> allDifferences)
        {
            decimal sum = 0;
            for (int i = 0; i < allDifferences.Count; i++)
            {
                if (allDifferences[i] % 2 != 0)
                {
                    sum += allDifferences[i];
                }
            }

            return sum;
        }

        private static IList<decimal> GetOddAbsoluteDifferences(decimal[] sequence)
        {
            int positionIndex = 1;
            decimal positionNumber = sequence[positionIndex];
            decimal absDif = Math.Abs(positionNumber - sequence[0]);

            var allDifferences = new List<decimal>();
            allDifferences.Add(absDif);

            while (true)
            {
                if (absDif % 2 == 0)
                {
                    if (positionIndex + 2 >= sequence.Length)
                    {
                        break;
                    }

                    positionNumber = sequence[positionIndex + 2];
                }
                else
                {
                    if (positionIndex + 1 >= sequence.Length)
                    {
                        break;
                    }

                    positionNumber = sequence[positionIndex + 1];
                }

                positionIndex = Array.IndexOf(sequence, positionNumber, positionIndex + 1);
                absDif = Math.Abs(positionNumber - sequence[positionIndex - 1]);
                allDifferences.Add(absDif);
            }

            return allDifferences;
        }
    }
}
