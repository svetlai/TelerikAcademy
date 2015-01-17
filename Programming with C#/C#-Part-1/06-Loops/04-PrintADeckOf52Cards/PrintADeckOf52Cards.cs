namespace PrintADeckOf52Cards
{
    using System;

    /// <summary>
    /// Problem 4. Print a Deck of 52 Cards
    /// Write a program that generates and prints all possible cards from a [standard deck of 52 cards](http://en.wikipedia.org/wiki/Standard_52-card_deck) (without the jokers).
    /// The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
    /// The card faces should start from 2 to A.
    /// Print each card face in its four possible suits: clubs, diamonds, hearts and spades.
    /// Use 2 nested for-loops and a switch-case statement.
    /// output
    /// 2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds
    /// 3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds
    /// ...  
    /// K of spades, K of clubs, K of hearts, K of diamonds
    /// A of spades, A of clubs, A of hearts, A of diamonds
    /// Note: You may use the suit symbols instead of text.
    /// </summary>
    public class PrintADeckOf52Cards
    { 
        public static void Main()
        {
            const int CardsInASuitCount = 13;
            Suits[] suits = { Suits.spades, Suits.clubs, Suits.hearts, Suits.diamonds };

            string card;
            string currentCard;

            for (int i = 2; i < CardsInASuitCount + 2; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    card = i.ToString();

                    switch (card)
                    {
                        case "11":
                            card = "J";
                            break;
                        case "12":
                            card = "Q";
                            break;
                        case "13":
                            card = "K";
                            break;
                        case "14":
                            card = "A";
                            break;
                    }

                    currentCard = string.Format("{0} of {1}", card, (char)suits[j]);
                    Console.Write("{0}", currentCard);

                    if (j < suits.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
