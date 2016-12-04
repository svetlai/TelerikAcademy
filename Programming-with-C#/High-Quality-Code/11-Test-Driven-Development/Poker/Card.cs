namespace Poker
{
    using System;

    public class Card : ICard
    {
        private CardFace face;
        private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face 
        {
            get
            {
                return this.face;
            }

            private set
            {
                if ((int)value < 2 || (int)value > 14)
                {
                    throw new ArgumentOutOfRangeException("Card Face value must be between 2 and 14");
                }

                this.face = value;
            }
        }

        public CardSuit Suit 
        {             
            get
            {
                return this.suit;
            }

            private set
            {
                if ((int)value < 1 || (int)value > 4)
                {
                    throw new ArgumentOutOfRangeException("Card Suit value must be between 1 and 4");
                }

                this.suit = value;
            }
        }

        public override string ToString()
        {
            return this.face + " of " + this.suit;
        }
    }
}
