using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public struct Position
    {
        public Position(int row, int col, short? value = null)
        {
            Row = row;
            Col = col;
            Value = value;
        }

        public int Row;
        public int Col;
        public short? Value;
    }
}
