using System;
using System.Collections;
class DailyCodingProblem
{

// Good morning! Here's your coding interview problem for today.

// This problem was asked by Google.

// Given a singly linked list and an integer k, remove the kth last element from the list. k is guaranteed to be smaller than the length of the list.

// The list is very long, so making more than one pass is prohibitively expensive.

// Do this in constant space and in one pass.

	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		List list1 = new List();
		list1.
		RemoveKthLastElement();
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	static bool RemoveKthLastElement(List list)
	{

	}
}