namespace TestDeck
{
    using NUnit.Framework;

    using Santase.Logic;
    using Santase.Logic.Cards;

    /// <summary>
    /// Code coverage 100%
    /// </summary>
    [TestFixture]
    public class TestDeck
    {
        private const int TotalCardsInDeck = 24;

        [Test]
        public void TestDeckGetNewDeck()
        {
            Deck deck = new Deck();
            Assert.AreEqual(TotalCardsInDeck, deck.CardsLeft);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(20)]
        public void TestGetNextCardShouldReturnCorrectNumberOfCardsLeft(int count)
        {
            Deck deck = new Deck();
            for (int i = 0; i < count; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(TotalCardsInDeck - count, deck.CardsLeft);
        }

        [Test]
        public void TestGetNextCardShouldThrow()
        {
            Deck deck = new Deck();
            for (int i = 0; i < TotalCardsInDeck; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws(typeof(InternalGameException), () => deck.GetNextCard());
        }

        [Test]
        public void TestChangeTrumpCard()
        {
            Deck deck = new Deck();
            var trumpCard = deck.GetTrumpCard;
            var newCard = new Card(CardSuit.Club, CardType.Ace);
            deck.ChangeTrumpCard(newCard);

            Assert.AreEqual(newCard, deck.GetTrumpCard);
        }
    }
}
