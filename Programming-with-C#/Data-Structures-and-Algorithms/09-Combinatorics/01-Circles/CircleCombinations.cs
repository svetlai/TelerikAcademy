namespace Circles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CircleCombinations
    {
        static void Main()
        {
            //var line = "YBBOY";
            //var line = "YYYBBBBB";
            var line = Console.ReadLine();

            char[] input = line.ToCharArray()
                .OrderBy(c => c)
                .ToArray();
            var hashSet = new HashSet<string>();
            FindCircleCombinations(input, 0, input.Length, hashSet);
            
            //Console.WriteLine(hashSet.Count);
            //foreach (var combo in hashSet)
            //{
            //    Console.WriteLine(combo);
            //}

            var totalCount = (int)Math.Ceiling((double)hashSet.Count / (input.Count() * 2 - 1));
            Console.WriteLine(totalCount);
            //GeneratePermutations(input, 0);
        }
        
        //static void GeneratePermutations(char[] input, int k)
        //{
        //    if (k >= input.Length)
        //    {
        //        Print(input);
        //    }
        //    else
        //    {
        //        GeneratePermutations(input, k + 1);
        //        for (int i = k + 1; i < input.Length; i++)
        //        {
        //            Swap(ref input[k], ref input[i]);
        //            GeneratePermutations(input, k + 1);
        //            Swap(ref input[k], ref input[i]);
        //        }
        //    }
        //}

        public static void FindCircleCombinations(char[] input, int start, int n, HashSet<string> hashSet)
        {
            AddToHashSet(input, hashSet);
            //Print(input);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (input[left] != input[right])
                    {
                        Swap(ref input[left], ref input[right]);
                        FindCircleCombinations(input, left + 1, n, hashSet);
                        
                    }
                }

                var firstElement = input[left];
                for (int i = left; i < n - 1; i++)
                {
                    input[i] = input[i + 1];
                }

                input[n - 1] = firstElement;
            }           
        }

        static void AddToHashSet<T>(T[] arr, HashSet<string> hashSet)
        {
            hashSet.Add(string.Join(", ", arr));
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
