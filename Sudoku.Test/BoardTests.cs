using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Sudoku.Core;

using NUnit.Framework;

namespace Sudoku.Test
{
    [TestFixtureAttribute]
    public class BoardTests : BaseTest
    {
        [TestAttribute]
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
    }
}
