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
			position.Evaluate();

			if(position.IsComplete)
				return position;
			else if(!position.IsValid)
				return null;

			var nextPos = GetNextOpenPosition(position);
		    if (nextPos != null)
		    {
				var newPositions = new List<Board>();
				foreach(var val in position.GetPossibleValuesAtPosition(nextPos.Value))
		        {
					var newPosition = new Board(position.Positions);
					newPosition[nextPos.Value] = val;

					newPositions.Add (newPosition);
		        }

				foreach(var board in newPositions)
				{
					var result = _solve_impl(board);

					if(result != null)
						return result;
				}
		    }

		    return null;
		}
         
        private static Position? GetNextOpenPosition(Board position)
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
