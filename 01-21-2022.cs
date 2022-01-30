using System;
using System.Collections.Generic;

class DailyCodingProblem
{

	// Good morning! Her'es you rcoding interview problem for today.
	// This problem was asked by Google.
	// Given two singly  linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.
	// For example, given A - 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8
	// In this example, assume nodes with the same value are the exact same node objects.
	// Do this in O(M + N) time (where M and N are the lengths of the lists) and constant space


	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		List<int> a = new List();
		a.Add(3);
		a.Add(7);
		a.Add(8);
		a.Add(10);

		List<int> b = new List();
		b.Add(99);
		b.Add(1);
		b.Add(8);
		b.Add(10)
		FindIntersectingNode();
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	static void FindIntersectingNode(List a, List b)
	{
		while
	}

	
}