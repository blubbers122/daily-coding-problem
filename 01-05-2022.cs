using System;
using System.Collections.Generic;
class DailyCodingProblem
{
	// 	This problem was asked by Stripe.

	// Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. 
	// The array can contain duplicates and negative numbers as well.

	// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

	// You can modify the input array in-place.
	static void Main(string[] args)
	{
		Console.WriteLine(FirstMissingPositiveInt(new int[] {3, 4, -1, 1})); // should be 2
		Console.WriteLine(FirstMissingPositiveInt(new int[] {1, 2, 0})); // should be 3

		Console.WriteLine(FirstMissingPositiveInt(new int[] {5, 3, -1, 1})); // should be 2
		Console.WriteLine(FirstMissingPositiveInt(new int[] {0, 0})); // should be 1
		Console.WriteLine(FirstMissingPositiveInt(new int[] {3, 2, -1, 1})); // should be 2
		Console.WriteLine(FirstMissingPositiveInt(new int[] {0, 0})); // should be 2
	}

	static int FirstMissingPositiveInt(int[] numbers) {
		int lowestMissing = 1;
		int lowestFound = 0;
		for (int i = 0; i < numbers.Length; i++) {
			int number = numbers[i];
			// if (number <= 0 || number > lowest) continue;

			// if (number == lowest) {
			// 	lowest = number + 1;
			// }
			lowestFound = Math.Min(number, lowestFound);
			

		}
		return lowest;
	}
}
