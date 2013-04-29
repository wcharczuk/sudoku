using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Solver
    {
        public Solver() { }
        public Solver(Board initialPositions)
        {
            InitialPositions = initialPositions;
        }

        public Board InitialPositions { get; set; }

        public Board Solve()
        {
            return _solve_impl(InitialPositions);
        }

        private static Board _solve_impl(Board position)
        {
            var nextPos = _get_next_open_pos(position);
            if (nextPos != null)
            {
                for(short val = 0; val < 9; val++)
                {
                    position[nextPos.Value] = val;
                }
            }

            return position;
        }
         
        private static Position? _get_next_open_pos(Board position)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var value = position[row, col];
                    if (value == null)
                        return new Position(row, col, null);
                }
            }
            return null;
        }
    }
}
