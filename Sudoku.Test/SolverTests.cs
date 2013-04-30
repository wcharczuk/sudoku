using System;
using NUnit.Framework;
using Sudoku.Core;

namespace Sudoku.Test
{
	[TestFixture()]
	public class SolverTests : BaseTest
	{
		[Test()]
		public void Solve ()
		{
			var board = GetValidBoard();
			var solver = new Solver(board);

			var solution = solver.Solve();

			Assert.NotNull(solution);
			Assert.IsTrue(solution.IsComplete);
			Assert.IsTrue(solution.IsValid);
		}
	}
}

