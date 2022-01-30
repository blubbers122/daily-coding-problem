using System;
using System.Collections;
class DailyCodingProblem
{

	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Google.

	// You are given an M by N matrix consisting of booleans that represents a board. Each True boolean represents a wall. Each False boolean represents a tile you can walk on.

	// Given this matrix, a start coordinate, and an end coordinate, return the minimum number of steps required to reach the end coordinate from the start. If there is no possible path, then return null. You can move up, left, down, and right. You cannot move through walls. You cannot wrap around the edges of the board.

	// For example, given the following board:

	// [[f, f, f, f],
	// [t, t, f, t],
	// [f, f, f, f],
	// [f, f, f, f]]
	// and start = (3, 0) (bottom left) and end = (0, 0) (top left), the minimum number of steps required to reach the end is 7, since we would need to go through (1, 2) because there is a wall everywhere else on the second row.

	// Questions:
	// 1. Can the matrix be rectangular?
	// 2. Is the matrix always solvable?
	// 2a. What to return if not solvable?
	// 3. Can the matrix be empty?
	// 4. How large can the matrix be?

	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		bool[][] board1 = new bool[][] {
			new bool[] { true, false, false, false },
			new bool[] { false, true, false, false },
			new bool[] { false, false, true, false },
			new bool[] { false, false, false, false }
		};
		bool[][] board2 = new bool[][] {
			new bool[] { false, false, false, false },
			new bool[] { true, true, false, true },
			new bool[] { false, false, false, false },
			new bool[] { false, false, false, false }
		};

		Console.WriteLine(ShortestPath(board1, (3, 0), (0, 3))); //  should be 6
		Console.WriteLine(ShortestPath(board2, (3, 0), (0, 0))); //  should be 7
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	static int ShortestPath(bool[][] board, (int x, int y) start, (int x, int y) end)
	{
		Stack frontier = new Stack();
		// HashSet seen = new HashSet();

		(int x, int y) current = start;
		int steps = 0;
		(int x, int y) left, right, up, down;

		frontier.Push(current);


		while (!(current.x == end.x && current.y == end.y) && frontier.Count != 0)
		{
			left = (current.x - 1, current.y);
			right = (current.x + 1, current.y);
			up = (current.x, current.y + 1);
			down = (current.x, current.y - 1);


			if (current.x > 0 && !board[left.x][left.y] && !frontier.Contains(left))
			{
				frontier.Push(left);
			}

			if (current.x < board.Length - 1 && !board[right.x][right.y] && !frontier.Contains(right))
			{
				frontier.Push(right);
			}

			if (current.y > 0 && !board[up.x][up.y] && !frontier.Contains(up))
			{
				frontier.Push(up);
			}

			if (current.y < board[0].Length - 1 && !board[down.x][down.y] && !frontier.Contains(down))
			{
				frontier.Push(down);
			}


			Tuple<int, int> next = (Tuple<int, int>)frontier.Pop();

			current = (next.Item1, next.Item2);
		}

		Console.WriteLine((current.x == end.x && current.y == end.y) ? "made it to the end!" : "ran out of options");

		return steps;

	}
}