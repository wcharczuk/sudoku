using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Core;

using NUnit.Framework;

namespace Sudoku.Test
{
    [TestFixture()]
    public class BoardTests : BaseTest
    {
        [Test()]
        public void GetBoardSquare()
        {
            Board valid = GetValidBoard();

            for (int x = 0; x < 9; x++)
            {
                Assert.IsTrue(valid.IsSquareValid(x));
                Assert.IsTrue(valid.IsRowValid(x));
                Assert.IsTrue(valid.IsColumnValid(x));
            }

            var invalid = GetInValidBoard();
            Boolean isValid = true;
            for (int x = 0; x < 9; x++)
            {
                isValid = isValid && invalid.IsSquareValid(x);
                isValid = isValid && invalid.IsRowValid(x);
                isValid = isValid && invalid.IsColumnValid(x);
            }
            Assert.IsFalse(isValid);

            var b = GetValidBoard();
            b.Evaluate();
            Assert.IsTrue(b.IsValid);
            Assert.IsFalse(b.IsComplete);

            b = GetInValidBoard();
            b.Evaluate();
            Assert.IsFalse(b.IsValid);
            Assert.IsFalse(b.IsComplete);
        }

		[Test]
		public void GetSquareForPosition()
		{
			Assert.AreEqual(Board.GetSquareForPosition(0,0), 0);
			Assert.AreEqual(Board.GetSquareForPosition(0,3), 1);
			Assert.AreEqual(Board.GetSquareForPosition(0,6), 2);
			Assert.AreEqual(Board.GetSquareForPosition(3,0), 3);
			Assert.AreEqual(Board.GetSquareForPosition(3,3), 4);
			Assert.AreEqual(Board.GetSquareForPosition(3,6), 5);
			Assert.AreEqual(Board.GetSquareForPosition(6,0), 6);
			Assert.AreEqual(Board.GetSquareForPosition(6,3), 7);
			Assert.AreEqual(Board.GetSquareForPosition(6,6), 8);

			Assert.AreEqual(Board.GetSquareForPosition(1,1), 0);
			Assert.AreEqual(Board.GetSquareForPosition(1,4), 1);
			Assert.AreEqual(Board.GetSquareForPosition(1,7), 2);
			Assert.AreEqual(Board.GetSquareForPosition(4,1), 3);
			Assert.AreEqual(Board.GetSquareForPosition(4,4), 4);
			Assert.AreEqual(Board.GetSquareForPosition(4,7), 5);
			Assert.AreEqual(Board.GetSquareForPosition(7,1), 6);
			Assert.AreEqual(Board.GetSquareForPosition(7,4), 7);
			Assert.AreEqual(Board.GetSquareForPosition(7,7), 8);

			Assert.AreEqual(Board.GetSquareForPosition(2,2), 0);
			Assert.AreEqual(Board.GetSquareForPosition(2,5), 1);
			Assert.AreEqual(Board.GetSquareForPosition(2,8), 2);
			Assert.AreEqual(Board.GetSquareForPosition(5,2), 3);
			Assert.AreEqual(Board.GetSquareForPosition(5,5), 4);
			Assert.AreEqual(Board.GetSquareForPosition(5,8), 5);
			Assert.AreEqual(Board.GetSquareForPosition(8,2), 6);
			Assert.AreEqual(Board.GetSquareForPosition(8,5), 7);
			Assert.AreEqual(Board.GetSquareForPosition(8,8), 8);
		}
    }
}
