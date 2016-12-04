namespace TestPlayerActionValidator
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Santase.Logic.Players;
    using Santase.Logic.Cards;
    using Santase.Logic;
    using Santase.Logic.RoundStates;
    using System.Collections.Generic;

    [TestClass]
    public class TestPlayerActionValidator
    {
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;

        [TestMethod]
        public void TestShouldReturnFalseIfPlayerCardsDoNotContainCard()
        {
            var validator = new PlayerActionValidater();
            var card = new Card(CardSuit.Club, CardType.Queen);
            var action = new PlayerAction(PlayerActionType.PlayCard, card, Announce.Twenty);
            var gameRound = new GameRound(firstPlayer, secondPlayer, PlayerPosition.SecondPlayer);
            var roundState = new MoreThanTwoCardsLeftRoundState(gameRound);
            var context = new PlayerTurnContext(roundState, card, 5);
            var playerCards = new List<Card>
            {
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Spade, CardType.Ace)
            };

            bool isValid = validator.IsValid(action, context, playerCards);

            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void TestShouldReturnTrueIfPlayerCardsContainCard()
        {
            var validator = new PlayerActionValidater();
            var card = new Card(CardSuit.Club, CardType.Queen);
            var action = new PlayerAction(PlayerActionType.PlayCard, card, Announce.Twenty);
            var gameRound = new GameRound(firstPlayer, secondPlayer, PlayerPosition.SecondPlayer);
            var roundState = new MoreThanTwoCardsLeftRoundState(gameRound);
            var context = new PlayerTurnContext(roundState, card, 5);
            var playerCards = new List<Card>
            {
                new Card(CardSuit.Club, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Spade, CardType.Ace)
            };

            bool isValid = validator.IsValid(action, context, playerCards);

            //Assert.AreEqual(Announce.None, action.Announce);

            //Assert.AreEqual(false, context.AmITheFirstPlayer);
            Assert.AreEqual(true, isValid);
            //I am first player
            //Assert.AreEqual(null, context.FirstPlayedCard);
        }

        [TestMethod]
        public void TestAnnounceShouldBeNoneIfCardNotQueenOrKing()
        {
            var validator = new PlayerActionValidater();
            var card = new Card(CardSuit.Club, CardType.Nine);
            var action = new PlayerAction(PlayerActionType.PlayCard, card, Announce.Twenty);
            var gameRound = new GameRound(firstPlayer, secondPlayer, PlayerPosition.SecondPlayer);
            var roundState = new MoreThanTwoCardsLeftRoundState(gameRound);
            var context = new PlayerTurnContext(roundState, card, 5);
            var playerCards = new List<Card>
            {
                new Card(CardSuit.Club, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Spade, CardType.Ace)
            };

            bool isValid = validator.IsValid(action, context, playerCards);

            Assert.AreEqual(Announce.None, action.Announce);

            //Assert.AreEqual(false, context.AmITheFirstPlayer);
            //Assert.AreEqual(true, isValid);
            //I am first player
            //Assert.AreEqual(null, context.FirstPlayedCard);
        }
    }
}
