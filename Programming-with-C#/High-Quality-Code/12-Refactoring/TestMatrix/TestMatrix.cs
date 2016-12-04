namespace TestMatrix
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Refactoring;

    /// <summary>
    /// 98,17 % covered
    /// </summary>
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsLessThanOne()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsMoreThanOneHunred()
        {
            Matrix matrix = new Matrix(101);
        }

        [TestMethod]
        public void TestWhenSizeIsOne()
        {
            Matrix matrix = new Matrix(1);
            Assert.AreEqual("  1", matrix.ToString(), "Matrix doesn't display correctly.");
        }

        [TestMethod]
        public void TestWhenSizeIsSix()
        {
            Matrix matrix = new Matrix(6);

            Assert.AreEqual(string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}",
                                            "  1 16 17 18 19 20",
                                            " 15  2 27 28 29 21",
                                            " 14 31  3 26 30 22",
                                            " 13 36 32  4 25 23",
                                            " 12 35 34 33  5 24",
                                            " 11 10  9  8  7  6"), 
                                            matrix.ToString(), "Matrix doesn't display correctly.");
        }
    }
}
