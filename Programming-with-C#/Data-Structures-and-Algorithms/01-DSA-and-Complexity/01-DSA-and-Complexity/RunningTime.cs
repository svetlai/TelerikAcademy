namespace DSAandComplexity
{
    using System;

    ////What is the expected running time of the following C# code? Explain why.
    public class RunningTime
    {
        public static void Main()
        {
            var matrix = new int[5, 4];
            Console.WriteLine(CalcSum(matrix, 0));
        }
        ////1. Complexity O(n*n); The for loop loops through all elements once and then the while 
        ////loop does the same -1 one more time. We're ignoring the constants since they don't have much affection.
        public static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0,
                    end = arr.Length - 1;

                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return count;
        }

        ////2. Complexity O(n*m) - the first loop makes n (matrix.GetLength(0)) operations to check if matrix[row, 0] % 2 == 0 is true 
        ////the second loop will make const*m (where m is matrix.GetLength(1) and const is the number of times the first if condition is true)
        ////operations to check if the second condition is true. We're ignoring the constants.
        public static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        ////Complexity O(m * n) - the for loop loops through m elements (matrix.GetLength(0))
        ////the if statement will make const*n operations (where const is the number of times the condition is true and n is matrix.GetLength(1)) 
        ////and then the method will repeat recursively n - 1 times;
        ////m + (n-1)*m = m*n
        public static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < matrix.GetLength(0))
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }
    }
}
