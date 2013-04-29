using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Core;

namespace Sudoku.Test
{
    public class BaseTest
    {
        public Board GetValidBoard()
        {
            var positions = new short?[9,9]
            {
                { null, null, null, null, null, null, null, 8, null },
                { 1, null, null, null, 6, null, 3, null, 2 },
                { null, 4, null, 1, null, null, 6, 5, null },
                { null, 8, null, null, null, 6, null, null, null },
                { 5, null, 4, null, null, null, 2, null, 3 },
                { null, null, null, 5, null, null, null, 4, null },
                { null, 9, 3, null, null, 7, null, 1, null },
                { 7, null, 2, null, 9, null, null, null, 5 },
                { null, 1, null, null, null, null, null, null, null },
            };

            return new Board(positions);
        }

        public Board GetInValidBoard()
        {
            var positions = new short?[9, 9]
            {
                { null, null,   null,   null,   null,   null,   null,   8,      null },
                { 1,    null,   null,   null,   6,      null,   3,      null,   2 },
                { null, 4,      null,   1,      null,   null,   6,      5,      null },
                { null, 8,      null,   null,   null,      6,      null,   null,   null },
                { 5,    null,   4,      null,   null,   null,   2,      null,   3 },
                { null, null,   5,      null,   null,   null,   null,   4,      null },
                { null, 9,      3,      null,   6,      7,      5,      1,      null },
                { 7,    null,   2,      null,   9,      null,   null,      null,   5 },
                { null, 1,      null,   null,   null,   null,   null,   null,   null },
            };

            return new Board(positions);
        }
    }
}
