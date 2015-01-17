namespace OddAndEvenProduct
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 10. Odd and Even Product
    /// You are given n integers (given in a single line, separated by a space).
    /// Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
    /// Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
    /// Examples:
    /// numbers	result
    /// 2 1 1 6 3	yes
    /// product = 6	
    /// 3 10 4 6 5 1	yes
    /// product = 60	
    /// 4 3 2 5 2	no
    /// odd_product = 16	
    /// even_product = 15
    /// </summary>
    public class OddAndEvenProduct
    {
        public static void Main()
        {
            Console.WriteLine("Problem 10. Odd and Even Product \nYou are given n integers (given in a single line, separated by a space). \nWrite a program that checks whether the product of the odd elements is equal to the product of the even elements. \nElements are counted from 1 to n, so the first element is odd, the second is even, etc.\n");

            Console.Write("Enter some integer numbers, separated by space: ");

            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll<string, int>(line, int.Parse);

            long oddProduct = 1;
            long evenProduct = 1;

            for (int i = 1; i <= numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    oddProduct *= numbers[i - 1];
                }
                else
                {
                    evenProduct *= numbers[i - 1];
                }
            }

            Console.WriteLine("Odd product == even prodict? --> {0}", oddProduct == evenProduct ? "yes" : "no");
        }
    }
}
