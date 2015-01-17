namespace CheckForAPlayCard
{
    using System;

    /// <summary>
    /// Problem 3. Check for a Play Card
    /// Classical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints yes if it is a valid card sign or no otherwise. 
    /// Examples:
    /// | character | Valid card sign? |
    /// |-----------|------------------|
    /// | 5         | yes              |
    /// | 1         | no               |
    /// | Q         | yes              |
    /// | q         | no               |
    /// | P         | no               |
    /// | 10        | yes              |
    /// | 500       | no               |
    /// </summary>
    public class CheckForAPlayCard
    {
        public static void Main()
        {
            const string AllCardSigns = "2345678910JQKA";

            Console.WriteLine("Problem 3. Check for a Play Card \nClassical play cards use the following signs to designate the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints yes if it is a valid card sign or no otherwise.\n");

            // display examples
            string[] characters = { "5", "1", "Q", "q", "P", "10", "500" };
            string result;

            Console.WriteLine("{0,10} | {1,10}", "character", "Valid card sign?");

            for (int i = 0; i < characters.Length; i++)
            {
                if (AllCardSigns.Contains(characters[i]))
                {
                    result = "yes";
                }
                else
                {
                    result = "no";
                }

                Console.WriteLine("{0,10} | {1,10}", characters[i], result);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it yourself! \nEnter a character: ");

            string character = Console.ReadLine();

            while (character != string.Empty)
            {
                if (AllCardSigns.Contains(character))
                {
                    result = "yes";
                }
                else
                {
                    result = "no";
                }

                Console.WriteLine("{0,10} | {1,10}", character, result);

                Console.Write("Enter a character: ");
                character = Console.ReadLine();
            }
        }
    }
}
