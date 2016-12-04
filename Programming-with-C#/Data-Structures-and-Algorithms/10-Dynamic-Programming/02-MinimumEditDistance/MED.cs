namespace Minimum_Edit_Distance
{
    using System;

    public class MEDSolution
    {
        const double CostDelete = 0.9;
        const double CostInsert = 0.8;
        const double CostReplace = 1;
        private static double[,] table;
        
        static void Main()
        {
            var distance = MED("developer", "enveloped");
            Console.WriteLine("developer -> enveloped");
            Console.WriteLine("MED: {0}", distance);
            PrintCostsTable();
        }

        public static double MED(string initialWord, string transformedWord)
        {
            table = new double[initialWord.Length + 1, transformedWord.Length + 1];

            for (int row = 0; row <= initialWord.Length; row++)
            {
                table[row, 0] = row * CostDelete;
                
            }

            for (int col = 0; col <= transformedWord.Length; col++)
            {
                table[0, col] = col * CostInsert;
            }

            double cost;
            for (int row = 1; row <= initialWord.Length; row++)
            {
                for (int col = 1; col <= transformedWord.Length; col++)
                {
                    if (transformedWord[col - 1] == initialWord[row - 1])
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = CostReplace;
                    }

                    double delete = table[row - 1, col] + CostReplace;
                    double replace = table[row - 1, col - 1] + cost;
                    double insert = table[row, col - 1] + CostInsert;

                    table[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            return table[initialWord.Length, transformedWord.Length];
        }

        public static void PrintCostsTable()
        {
           Console.WriteLine();

           for (int row = 0; row < table.GetLength(0); row++)
           {
               for (int col = 0; col < table.GetLength(1); col++)
               {
                   Console.Write("{0, 4} ", table[row, col]);
               }
           }

           Console.WriteLine();
        }
    }
}
