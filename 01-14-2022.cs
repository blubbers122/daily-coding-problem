using System;
using System.Collections.Generic;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Amazon.

	// Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.

	// For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".

	// Upgrade to premium and get in-depth solutions to every problem, including this one.

	// If you liked this problem, feel free to forward it along so they can subscribe here! As always, shoot us an email if there's anything we can help with!
	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		Console.WriteLine(LongestSubstringWithDistinctChars(2, "abcba")); // should be "bcb"
		Console.WriteLine(LongestSubstringWithDistinctChars(3, "abcba")); // should be "abcba"
		Console.WriteLine(LongestSubstringWithDistinctChars(4, "abcba")); // should be "abcba"
		Console.WriteLine(LongestSubstringWithDistinctChars(1, "abcba")); // should be "a"
		Console.WriteLine(LongestSubstringWithDistinctChars(1, "abaabc")); // should be "aa"



		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	// Not quite finished
	static string LongestSubstringWithDistinctChars(int k, string s)
	{
		if (s.Length == 0) return "";
		string longest = "";
		string current = "";
		HashSet<int> set = new HashSet<int>();
		for (int i = 0; i < s.Length; i++)
		{
			char c = s[i];
			if (set.Add(c) && set.Count > k)
			{ // unique char was added to the set and we've exceeded max distinct chars
				char firstDistinctChar = current[0];
				set.Remove(firstDistinctChar);
				for (int j = 0; j < current.Length; j++)
				{ // instead of looping through, we might be able to store it as we find it
					if (current[j] != firstDistinctChar)
					{
						current = current.Substring(j);
					}
				}
			}
			current += c;
			longest = current.Length > longest.Length ? current : longest;


		}

		return longest;
	}
}