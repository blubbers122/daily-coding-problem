using System;
class DailyCodingProblem
{
	static void Main(string[] args)
	{
		int[] array = { -1, 1, 1, -1, 18, 19, 17, 17 };
		ContainsAddends(array, 18);
	}

	private static bool ContainsAddends(int[] numbers, int sum) {
		int k = 1;
		for (int i = 0; i < numbers.Length; i++) {
			for (int j = k; j < numbers.Length; j++) {
				if (numbers[i] + numbers[j] == sum) {
					
					Console.WriteLine(sum + " Contains Addends: " + numbers[i] + " and " + numbers[j]);
					return true;
				}
			}
			k++;
		}
		Console.WriteLine("The array does not contain any addends for sum " + sum);
		return false;
	}
}
