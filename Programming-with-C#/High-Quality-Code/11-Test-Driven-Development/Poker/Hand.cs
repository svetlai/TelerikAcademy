namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        private const int CardsInHandCount = 5;
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards 
        {
            get
            {
                IList<ICard> cardsList = new List<ICard>();
                Card currentCard;
                foreach (var card in this.cards)
                {
                    currentCard = new Card(card.Face, card.Suit);
                    cardsList.Add(currentCard);
                }
                
                return cardsList;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of cards cannot be null.");
                }

                this.cards = new List<ICard>();

                foreach (var card in value)
                {
                    Card currentCard = new Card(card.Face, card.Suit);
                    this.cards.Add(currentCard);
                }
            }
        }

        public void Sort()
        {
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder("Hand");

            if (this.cards.Count == 0)
            {
                hand.Append(" is empty.");
            }
            else
            {
                hand.Append(": ");
                foreach (var card in this.cards)
                {
                    hand.Append(card);
                    hand.Append(", ");
                }

                hand.Length = hand.Length - 2;
            }

            return hand.ToString();
        }
    }
}
