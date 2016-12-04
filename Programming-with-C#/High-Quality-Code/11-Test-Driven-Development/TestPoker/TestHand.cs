//-----------------------------------------------------------------------
// <copyright file="TestHand.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the TestHand class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// Class for testing the <see cref="Hand"/> class.
    /// </summary>
    [TestClass]
    public class TestHand
    {
        /// <summary>
        /// Tests if new hand is created correctly.
        /// </summary>
        [TestMethod]
        public void TestNewHand()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
        }

        /// <summary>
        /// Test if the private cards object created in the constructor is accessible through the object we pass
        /// in the constructor, and if it is encapsulated correctly.
        /// </summary>
        [TestMethod]
        public void TestSetHandAsNewObject()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
            cards.Clear();
            string errorMessage = "The constructor does not creat new object but assigns the value passed to the setter by refference" +
                ", exposing the private member cards, and breaking encapsulation";
            Assert.AreEqual(1, hand.Cards.Count, errorMessage);
        }

        /// <summary>
        /// Test if the object we get from the getter is a new object and the private
        /// property cards is encapsulated correctly. 
        /// </summary>
        [TestMethod]
        public void TestGetHandAsNewObject()
        {
            IList<ICard> cards = new List<ICard>()
                {
                    new Card(CardFace.Two, CardSuit.Clubs)
                };

            Hand hand = new Hand(cards);
            IList<ICard> testCard = hand.Cards;
            Assert.AreEqual(false, object.ReferenceEquals(hand.Cards, testCard), "The getter returns the private object cards, not a new object.");
        }

        /// <summary>
        /// Test assigning null to the card parameter of the constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The Cards property setter allows null value.")]
        public void TestHandConstructorErrorForNullParameter()
        {
            Hand hand = new Hand(null);
        }

        /// <summary>
        /// Test if the output string is correct when the hand is empty.
        /// </summary>
        [TestMethod]
        public void TestHandToStringForEmptyHand()
        {
            IList<ICard> cards = new List<ICard>();

            Hand hand = new Hand(cards);
            Assert.AreEqual("Hand is empty.", hand.ToString(), "Incorect ToString value for empty hand");
        }

        /// <summary>
        /// Test if the output string is correct for all cards in the hand.
        /// </summary>
        [TestMethod]
        public void TestHandToStringForAllCardsInOneHand()
        {
            Hand hand;
            IList<ICard> cards = new List<ICard>();
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Hand: ");

            foreach (var cardFace in Enum.GetValues(typeof(CardFace)))
            {
                foreach (var cardSuit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new Card((CardFace)cardFace, (CardSuit)cardSuit));
                    outputString.Append(cardFace.ToString() + " of " + cardSuit.ToString() + ", ");
                }
            }

            outputString.Length = outputString.Length - 2;

            hand = new Hand(cards);
            Assert.AreEqual(outputString.ToString(), hand.ToString(), "Incorect ToString return value for all cards in hand.");
        }
    }
}