namespace Knacksack_Problem
{
    using System;
    using System.Collections.Generic;

    public class Knapsack
    {
        public static void Main()
        {
            const int capacity = 10;
            int totalWeight = 0;
            int totalCost = 0;

            List<Item> items = new List<Item>
            {
                new Item("beer", 3, 2),
                new Item("vodka", 8, 12),
                new Item("cheese", 4, 5),
                new Item("nuts", 1, 4),
                new Item("ham", 2, 3),
                new Item("whiskey", 8, 13),
                new Item("bread", 1, 2),
                new Item("melon", 3, 5),
            };

            List<Item> sack = KnapsackSolution(items, capacity);
            foreach (var item in sack)
            {
                totalWeight += item.Weight;
                totalCost += item.Cost;
                Console.WriteLine("Best choice: {0}, weight: {1}, value {2}", item.Name, item.Weight, item.Cost); 
            }

            Console.WriteLine("Total weight: {0}", totalWeight);
            Console.WriteLine("Total cost: {0}", totalCost);
        }

        public static List<Item> KnapsackSolution(List<Item> items, int capacity)
        {
            var keep = new int[items.Count + 1, capacity + 1];
            var costs = new int[items.Count + 1, capacity + 1];

            for (int i = 1; i < items.Count + 1; i++)
            {
                for (int k = capacity; k >= 0; k--)
                {
                    if (items[i - 1].Weight <= k)
                    {
                        int remainingSpace = k - items[i - 1].Weight;

                        if (remainingSpace > 0)
                        {
                            int cost = costs[i - 1, k];
                            int sumCost = items[i - 1].Cost + costs[i - 1, remainingSpace - 1];

                            if (cost > sumCost)
                            {
                                costs[i, k] = cost;
                                keep[i, k] = 0;
                            }
                            else
                            {
                                costs[i, k] = sumCost;
                                keep[i, k] = 1;
                            }
                        }
                        else
                        {
                            costs[i, k] = items[i - 1].Cost;
                            keep[i, k] = 1;
                        }
                    }
                }
            }

            List<Item> bestChoice = new List<Item>();

            int space = capacity;
            int count = items.Count;

            while (count >= 0)
            {
                int toBeAdded = keep[count, space - 1];

                if (toBeAdded == 1)
                {
                    bestChoice.Add(items[count - 1]);
                    space -= items[count - 1].Weight;
                }

                count--;
            }

            return bestChoice;
        }
    }
}
