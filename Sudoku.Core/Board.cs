using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Board
    {
		#region Static Methods
		public static int GetSquareForPosition(int row, int col)
		{
			int majorRow = row / 3;
			int majorCol = col / 3;
			
			return (majorRow * 3) + majorCol;
		}
		
		public static HashSet<short> AllPossibleValues()
		{
			return new HashSet<short>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		}
		#endregion

        public Board() { IsValid = true; IsComplete = true; }
        public Board(short?[,] positions) : this()
        {
			this._positions = positions.Clone () as short?[,];
        }
		
        private short?[,] _positions = new short?[9, 9];

		public short?[,] Positions { get { return _positions; }}

		public Boolean IsComplete { get; set; }
		public Boolean IsValid { get; set; }

        public short? this[int row, int col]
        {
            get
            {
                return _positions[row, col];
            }
            set
            {
                if (value < 1 || value > 9)
                    throw new ArgumentException("Invalid board value.");

                _positions[row, col] = value;
            }
        }

        public short? this[Position pos]
        {
            get
            {
                return this[pos.Row, pos.Col];
            }
            set
            {
                this[pos.Row, pos.Col] = value;
            }
        }

        public void Evaluate()
        {
            IsValid = true;
            IsComplete = true;

            for (int x = 0; x < 9; x++)
            {
                IsValid = IsValid && IsSquareValid(x);
                IsValid = IsValid && IsRowValid(x);
                IsValid = IsValid && IsColumnValid(x);

                IsComplete = IsComplete && IsSquareComplete(x);
                IsComplete = IsComplete && IsRowComplete(x);
                IsComplete = IsComplete && IsColumnComplete(x);
            }
        }

        public Boolean IsSquareValid(int square)
        {
            int startCol = 0 + (3 * (square % 3));
            int endCol = 3 + (3 * (square % 3));

            int startRow = 0;
            int endRow = 3;

            switch (square)
            {
                case 0:
                case 1:
                case 2:
                    startRow = 0;
                    endRow = 3;
                    break;
                case 3:
                case 4:
                case 5:
                    startRow = 3;
                    endRow = 6;
                    break;
                case 6: 
                case 7:
                case 8:
                    startRow = 6;
                    endRow = 9;
                    break;
            }

            var values = new HashSet<short>();
            for (int row = startRow; row < endRow; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    var value = _positions[row, col];
                    if (value != null)
                    {
                        if (values.Contains(value.Value))
                            return false;

                        values.Add(value.Value);
                    }
                }
            }
            return true;
        }

        public Boolean IsRowValid(int row)
        {
            var values = new HashSet<short>();
            for (int col = 0; col < 9; col++)
            {
                var value = _positions[row, col];
                if (value != null)
                {
                    if (values.Contains(value.Value))
                        return false;

                    values.Add(value.Value);
                }
            }
            return true;
        }

        public Boolean IsColumnValid(int col)
        {
            var values = new HashSet<short>();
            for (int row = 0; row < 9; row++)
            {
                var value = _positions[row, col];
                if (value != null)
                {
                    if (values.Contains(value.Value))
                        return false;

                    values.Add(value.Value);
                }
            }
            return true;
        }

        public Boolean IsSquareComplete(int square)
        {
            int startCol = 0 + (3 * (square % 3));
            int endCol = 3 + (3 * (square % 3));
            int startRow = 0;
            int endRow = 3;

            switch (square)
            {
                case 0:
                case 1:
                case 2:
                    startRow = 0;
                    endRow = 3;
                    break;
                case 3:
                case 4:
                case 5:
                    startRow = 3;
                    endRow = 6;
                    break;
                case 6:
                case 7:
                case 8:
                    startRow = 6;
                    endRow = 9;
                    break;
            }

            var values = new HashSet<short>();
            for (int row = startRow; row < endRow; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    var value = _positions[row, col];
                    if (value != null)
                    {
                        if (!values.Contains(value.Value))
                            values.Add(value.Value);
                    }
                }
            }
            return values.Count == 9;
        }

        public Boolean IsRowComplete(int row)
        {
            var values = new HashSet<short>();
            for (int col = 0; col < 9; col++)
            {
                var value = _positions[row, col];
                if (value != null)
                {
                    if (!values.Contains(value.Value))
                        values.Add(value.Value);
                }
            }
            return values.Count == 9;
        }

        public Boolean IsColumnComplete(int col)
        {
            var values = new HashSet<short>();
            for (int row = 0; row < 9; row++)
            {
                var value = _positions[row, col];
                if (value != null)
                {
                    if (!values.Contains(value.Value))
                        values.Add(value.Value);
                }
            }
            return values.Count == 9;
        }

		public IEnumerable<short> GetPossibleValuesAtPosition(Position position)
		{
			return GetPossibleValuesAtPosition(position.Row, position.Col);
		}

		public IEnumerable<short> GetPossibleValuesAtPosition(int row, int col)
		{
			var squareSet = GetPossibleValuesForSquare(GetSquareForPosition(row, col));
			var rowSet = GetPossibleValuesForRow(row);
			var columnSet = GetPossibleValuesForColumn(col);

			return squareSet.Intersect(rowSet.Intersect(columnSet));
		}

		public HashSet<short> GetPossibleValuesForSquare(int square)
		{
			int startCol = 0 + (3 * (square % 3));
			int endCol = 3 + (3 * (square % 3));
			int startRow = 0;
			int endRow = 3;
			
			switch (square)
			{
			case 0:
			case 1:
			case 2:
				startRow = 0;
				endRow = 3;
				break;
			case 3:
			case 4:
			case 5:
				startRow = 3;
				endRow = 6;
				break;
			case 6:
			case 7:
			case 8:
				startRow = 6;
				endRow = 9;
				break;
			}

			var allPossibles = AllPossibleValues();
			for (int row = startRow; row < endRow; row++)
			{
				for (int col = startCol; col < endCol; col++)
				{
					var value = _positions[row, col];
					if (value != null)
					{
						allPossibles.Remove (value.Value);
					}
				}
			}
			return allPossibles;
		}

		public HashSet<short> GetPossibleValuesForRow(int row)
		{
			var allPossibles = AllPossibleValues();

			for (int col = 0; col < 9; col++)
			{
				var value = _positions[row, col];
				if (value != null)
				{
					allPossibles.Remove(value.Value);
				}
			}

			return allPossibles;
		}

		public HashSet<short> GetPossibleValuesForColumn(int col)
		{
			var allPossibles = AllPossibleValues();
			
			for (int row = 0; row < 9; row++)
			{
				var value = _positions[row, col];
				if (value != null)
				{
					allPossibles.Remove(value.Value);
				}
			}
			
			return allPossibles;
		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder();
			for(int row = 0; row < 9; row++)
			{
				for(int col = 0; col < 9; col++)
				{
					if(_positions[row, col] == null)
						sb.Append("-");
					else
						sb.Append(_positions[row, col].ToString());

					sb.Append(" ");
				}
				sb.Append("\r\n");
			}
			return sb.ToString();
		}
    }
}
