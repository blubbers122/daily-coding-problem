using System;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Airbnb.

	// Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.

	// For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.

	// Follow-up: Can you do this in O(N) time and constant space?
	static void Main(string[] args)
	{
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 2, 4, 6, 2, 5 })); // should be 13
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 2, 4, 6, 2, 5, 10 })); // should be 18 (2, 6, 10)
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 5, 1, 1, 5 })); // should be 10
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 5 })); // should be 5
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 1, 5 })); // should be 5
		Console.WriteLine(LargestSumOfNonAdjacent(new int[] { 5, 1, -100, 5 })); // should be 10
		Console.WriteLine(LargestSumOfNonAdjacent(null));
	}

	static int LargestSumOfNonAdjacent(int[] numbers)
	{
		if (numbers == null || numbers.Length == 0)
		{
			return 0;
		}
		if (numbers.Length == 1)
		{
			return numbers[0];
		}

		int[] sums = new int[numbers.Length]; // sums[i] is the largest sum of non-adjacent numbers up to and including numbers[i]
		sums[0] = numbers[0];
		sums[1] = Math.Max(numbers[0], numbers[1]);

		for (int i = 2; i < numbers.Length; i++)
		{ // this loop runs for arrays of length > 2 and determines which numbers to skip

			// the last element in sums is always the largest sum of non-adjacent numbers found so far.
			// If we notice the current largest sum is less than the sum of the current number and the last sum, the next sum becomes the current number plus the second largest sum.
			sums[i] = Math.Max(sums[i - 1], sums[i - 2] + numbers[i]);
		}

		return sums[sums.Length - 1];
	}
}