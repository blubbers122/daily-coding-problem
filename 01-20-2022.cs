using System;
class DailyCodingProblem
{

	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Facebook.

	// A builder is looking to build a row of N houses that can be of K different colors. He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.

	// Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.

	


	// ** This question is incredibly unclear

	// Questions
	// 1. What can the matrix be filled with? (ints, decimals, negatives, zeroes?)
	// 2. are we picking an existing row or column that satisfies this, or picking and choosing from the array
	// 3. how big can n and k be?
	// 4. give an example of an input matrix

	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		int[][] houseMatrix1 = {
			{1,2,3},
			{2,3,5},
			{1,2,3}
		}; // n = 3, k = 3
		CheapestRowOfHouses(houseMatrix1);
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	static int CheapestRowOfHouses(int[][] houses)
	{
		int minCost;
		for (int n = 0; n < houses.Length; n++) {
			int[] houseRow = houses[n];
			for (int k = 0; k < houseRow; k++) {

			}
		}
		return minCost;
	}
}