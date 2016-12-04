using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameResultValidatorTest
    {
        private IGameResultValidator validator;

        public GameResultValidatorTest()
        {
            this.validator = new GameResultValidator();
        }

        [TestMethod]
        public void GetResult_When3VerticalO_ShouldReturnWonByOTest()
        {
            var board = "OX-OXXO--";
            var expected = GameResult.WonByO;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_When3HorizontalO_ShouldReturnWonByOTest()
        {
            var board = "XX-OOOX--";
            var expected = GameResult.WonByO;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_When3DiagonalO_ShouldReturnWonByOTest()
        {
            var board = "XXOXOOO--";
            var expected = GameResult.WonByO;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_When3VerticalX_ShouldReturnWonByOTest()
        {
            var board = "XO-XOOX--";
            var expected = GameResult.WonByX;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_When3HorizontalX_ShouldReturnWonByOTest()
        {
            var board = "OO-XXXO--";
            var expected = GameResult.WonByX;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_When3DiagonalX_ShouldReturnWonByOTest()
        {
            var board = "XOOXXO--X";
            var expected = GameResult.WonByX;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_WhenBoardFullAndNoneWon_ShouldReturnDrawTest()
        {
            var board = "XOXOXXOXO";
            var expected = GameResult.Draw;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetResult_WhenBoardNotFullAndNoneWon_ShouldReturnNotFinishedTest()
        {
            var board = "XOXOXXO-O";
            var expected = GameResult.NotFinished;
            var actual = this.validator.GetResult(board);
            Assert.AreEqual(actual, expected);
        }
    }
}
