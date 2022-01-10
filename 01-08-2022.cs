using System;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Facebook.

	// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.

	// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

	// You can assume that the messages are decodable. For example, '001' is not allowed.
	static void Main(string[] args)
	{
		Console.WriteLine(NumberOfUniqueDecodings("111")); // should be 3 'aaa', 'ka', 'ak
		Console.WriteLine(NumberOfUniqueDecodings("1")); // should be 1 'a'
		Console.WriteLine(NumberOfUniqueDecodings("11")); // should be 2 'aa', 'k'
		Console.WriteLine(NumberOfUniqueDecodings("27")); // should be 1 'bg'
		Console.WriteLine(NumberOfUniqueDecodings("10")); // should be 1 'j'
		Console.WriteLine(NumberOfUniqueDecodings("22222222")); // should be 1 + 7 + 15 + 10 + 1 = 34
																														// 'bbbbbbbb', 1
																														// 'vbbbbbb', 'bvbbbbb', 'bbvbbbb', 'bbbvbbb', 'bbbbvbb', 'bbbbbvb', 'bbbbbbv' 7
																														// 'vvbbbb', 'bvvbbb', 'bbvvbb', 'bbbvvb', 'bbbbvv', 'vbvbbb', 'vbbvbb', 'vbbbvb', 'vbbbbv', 'bvbvbb', 'bvbbvb', 'bvbbbv', 'bbvbvb', 'bbvbbv', 'bbbvbv' 15
																														// 'bbvvv', 'vbbvv', 'vvbbv', 'vvvbb', 'bvbvv', 'bvvbv', 'bvvvb', 'vbvbv', 'vbvvb', 'vvbvb' 10
																														// 'vvvv' 1
		// Console.WriteLine(UniqueDecodings("111"));
	}


	static int NumberOfUniqueDecodings(string message) {
		if (message.Length == 0) return 0;
		int[] dp = new int[message.Length + 1];
		dp[0] = 1;
		dp[1] = message[0] == '0' ? 0 : 1;
		for (int i = 2; i <= message.Length; i++) {
			int first = Convert.ToInt32(message.Substring(i - 1, 1));
			int second = Convert.ToInt32(message.Substring(i - 2, 2));
			if (first >= 1 && first <= 9) { // 1-9 can decode as a-j
				dp[i] = dp[i - 1];
			}
			if (second >= 10 && second <= 26) {
				dp[i] += dp[i - 2];
			}
		}
		return dp[message.Length];
	}
}