//-----------------------------------------------------------------------
// <copyright file="TestCard.cs" company="PokerCo">
//     PokerCo.
// </copyright>
// <summary>This is the TestCard class.</summary>
//-----------------------------------------------------------------------
namespace TestPoker
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// Class for testing the <see cref="Card"/> class.
    /// </summary>
    [TestClass]
    public class TestCard
    {
        /// <summary>
        /// Tests Card creation.
        /// </summary>
        [TestMethod]
        public void TestCardCreation()
        {
            ICard card;
            for (int i = (int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    Assert.AreEqual((CardFace)i, card.Face, "Card face of the new card is not correct");
                    Assert.AreEqual((CardSuit)j, card.Suit, "Card suit of the new card is not correct");
                }
            }
        }

        /// <summary>
        /// Test exception when an incorrect face, greater than 14, is given as parameter.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceGreaterThenCardFaceEnum()
        {
            ICard card = new Card((CardFace)15, CardSuit.Clubs);
        }

        /// <summary>
        /// Test exception when an incorrect face, less than 2, is given as parameter.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidFaceLessThenCardFaceEnum()
        {
            ICard card = new Card((CardFace)1, CardSuit.Clubs);
        }

        /// <summary>
        /// Test exception when an incorrect suit, less than 1, is given as parameter.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitGreaterThenCardSuitEnum()
        {
            ICard card = new Card(CardFace.Two, (CardSuit)0);
        }

        /// <summary>
        /// Test exception when an incorrect suit, greater than 4, is given as parameter.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardInvalidSuitLessThenCardSuitEnum()
        {
            ICard card = new Card(CardFace.Two, (CardSuit)5);
        }

        /// <summary>
        /// Tests if Card.ToString() method returns correct string.
        /// </summary>
        [TestMethod]
        public void TestCardToString()
        {
            ICard card;
            string cardName;
            for (int i = (int)CardFace.Two; i <= (int)CardFace.Ace; i++)
            {
                for (int j = (int)CardSuit.Clubs; j <= (int)CardSuit.Spades; j++)
                {
                    card = new Card((CardFace)i, (CardSuit)j);
                    cardName = string.Concat(((CardFace)i).ToString(), " of ", ((CardSuit)j).ToString());
                    Assert.AreEqual(cardName, card.ToString(), "Card name returned from ToString() is not correct");
                }
            }
        }
    }
}