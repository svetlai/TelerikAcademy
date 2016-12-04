//-----------------------------------------------------------------------
// <copyright file="TestPokerHandsChecker.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the TestPokerHandsChecker class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// Class for testing the <see cref="PokerHandsChecker"/> class.
    /// </summary>
    [TestClass]
    public class TestPokerHandsChecker
    {
        /// <summary>
        /// Test if a hand is with valid size.
        /// </summary>
        [TestMethod]
        public void TestIsValidHandSize()
        {
            IList<ICard> cards = new List<ICard>();
            IHand hand;
            IPokerHandsChecker handChecker = new PokerHandsChecker();

            foreach (var card in cards)
            {
                cards.Add(new Card(card.Face, card.Suit));
                hand = new Hand(cards);
                if (cards.Count == 5)
                {
                    Assert.AreEqual(true, handChecker.IsValidHand(hand), "Valid 5 cards hand is considered as invalid by the method.");
                }
                else
                {
                    Assert.AreEqual(false, handChecker.IsValidHand(hand), "Invalid size hand is considered as invalid by the method.");
                }
            }
        }

        /// <summary>
        /// Tests if IsValid() returns false for invalid hand.
        /// </summary>
        [TestMethod]
        public void TestIsValidShouldReturnFalse()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            IPokerHandsChecker handChecker = new PokerHandsChecker();
            Assert.AreEqual(false, handChecker.IsValidHand(hand), string.Format("Hand checker returns true for invalid hand {0}", hand));
        }

        /// <summary>
        /// Test IsFlush() is correct
        /// </summary>
        [TestMethod]
        public void TestIsFlushCorrect()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(true, handChecker.IsFlush(hand), string.Format("Flush returns false for flush hand {0}", hand));           
        }

        /// <summary>
        /// Test IsFourOfAKind() is correct
        /// </summary>
        [TestMethod]
        public void TestIsFourOfAKindCorrect()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(true, handChecker.IsFourOfAKind(hand), string.Format("Four of a kind returns false for hand {0}", hand));           
        }

        /// <summary>
        /// Test IsStraightFlush() is correct
        /// </summary>
        [TestMethod]
        public void TestIsStraightFlushCorrect()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            IPokerHandsChecker handChecker = new PokerHandsChecker();

            Assert.AreEqual(true, handChecker.IsStraightFlush(hand), string.Format("IsStraightFlush returns false hand {0}", hand));
        }
    }
}