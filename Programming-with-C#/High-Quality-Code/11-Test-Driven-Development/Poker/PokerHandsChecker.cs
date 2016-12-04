namespace Poker
{
    using System;
using System.Collections.Generic;
using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidHandLength = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != ValidHandLength)
            {
                return false;
            }

            var duplicates = hand.Cards.GroupBy(card => new { card.Face, card.Suit })
                              .Where(card => card.Skip(1).Any());

            if (duplicates.Any())
            {
                return false;
            }

            return true;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit suit = hand.Cards[0].Suit;

            for (int i = 0; i < ValidHandLength; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (!this.IsFlush(hand))
            {
                return false;
            }

            hand.Sort();

            for (int i = 1; i < ValidHandLength; i++)
            {
                if (hand.Cards[i - 1].Face + 1 != hand.Cards[i].Face)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int count = 0;
            CardFace currentFace = hand.Cards[0].Face;

            for (int i = 0; i < ValidHandLength; i++)
            {
                if (hand.Cards[i].Face == currentFace)
                {
                    count++;
                }
            }

            return true;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
