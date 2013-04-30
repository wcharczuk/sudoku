using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sudoku.Core;

namespace Sukoku
{
    class Program
    {
        static void Main(string[] args)
        {
			Stream inputStream = null;

			if(args.Length > 0)
				inputStream = File.Open(args[0], FileMode.Open);
			else 
				inputStream = Console.OpenStandardInput();

			var board = new Board();
			using(StreamReader sr = new StreamReader(inputStream))
	        {
				int row = 0;
				while(!sr.EndOfStream)
				{
					var line = sr.ReadLine();

					String[] pieces = null;

					if(line.Contains(","))
						pieces = line.Split(',');
					else if(line.Contains(" "))
						pieces = line.Split(' ');

					int col = 0;
					foreach(string val in pieces)
					{
						if(val == "-" || val == "0" || String.IsNullOrEmpty(val))
							board[row,col] = null;
						else
							board[row, col] = short.Parse(val);

						col++;
					}

					row++;
				}
			}

			Solver solver = new Solver(board);
			var solution = solver.Solve();
			
			for(int row = 0; row < 9; row++)
			{
				var values = new List<short?>();
				for(int col = 0; col < 9; col++)
				{
					values.Add (solution[row, col]);
				}

				Console.WriteLine(String.Join(",", values));
			}
        }
    }
}
