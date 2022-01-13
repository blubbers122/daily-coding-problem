using System;
using System.Collections.Generic;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Twitter.

	// Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.

	// For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].

	// Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.


	// Important questions to ask:
	// 1. Do we need to return the strings in order?
	// 2. Do we check if the items start with the query string or contain it?
	static void Main(string[] args)
	{
		PrintArray(AutoComplete("de", new string[] { "dog", "deer", "deal" })); // Should return [deer, deal]
		PrintArray(AutoComplete("de", new string[] { "eddy", "beer", "tear" })); // Should return []
		PrintArray(AutoComplete("de", new string[] {  })); // Should return []
	}

	static void PrintArray(List<string> array) {
		Console.Write("[");
		foreach (string s in array) {
			Console.Write(s + ", ");
		}
		Console.WriteLine("]");
	}

	static List<string> AutoComplete(string searchString, string[] dataSet) {
		List<string> results = new List<string>();
		foreach (string item in dataSet) {
			if (item.StartsWith(searchString)) {
				results.Add(item);
			}
		}
		return results;
	}

}