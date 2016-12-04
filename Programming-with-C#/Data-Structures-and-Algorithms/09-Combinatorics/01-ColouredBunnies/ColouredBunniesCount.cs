namespace Coloured_Bunnies
{
    using System;
    using System.Collections.Generic;

    public class ColouredBunniesCount
    {
        public static void Main()
        {

            var bunniesCount = int.Parse(Console.ReadLine());
            //int[] replies = { 2, 2, 44, 2, 2, 2, 444, 2, 2 };
            int[] replies = new int[bunniesCount];
            
            for (int i = 0; i < bunniesCount; i++)
            {
                replies[i] = int.Parse(Console.ReadLine());
            }
            
            var colourGroupsCount = new Dictionary<int, int>();
            var minBunnies = 0;

            foreach (var reply in replies)
            {
                int colourGroup = reply + 1;

                if (colourGroupsCount.ContainsKey(colourGroup))
                {
                    colourGroupsCount[colourGroup]++;
                }
                else
                {
                    colourGroupsCount.Add(colourGroup, 1);
                }         
            }

            foreach (var pair in colourGroupsCount)
            {
                if (pair.Key > pair.Value)
                {
                    minBunnies += pair.Key;
                }
                else
                {
                    minBunnies += (int)Math.Ceiling((double)pair.Value / (pair.Key)) * (pair.Key);
                }
            }

            Console.WriteLine(minBunnies);
        }
    }
}