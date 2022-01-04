using System;
class DailyCodingProblem
{
	static void Main(string[] args)
	{
		int[] newArray = ProductOfOthersInArray(new int[] { 1, 2, 3, 4, 5 });
		int[] newArray1 = ProductOfOthersInArray(new int[] { 3 , 2, 1 });
		int[] newArray2 = ProductOfOthersInArray(new int[] { 1 });
		int[] newArray3 = ProductOfOthersInArray(new int[] {  });
		int[] newArray4 = ProductOfOthersInArray(new int[] { 1, 2 });
		int[] newArray5 = ProductOfOthersInArray(new int[] { 0 });
		int[] newArray6 = ProductOfOthersInArray(new int[] { 0, 10, 10, 10, 10 });
		Console.WriteLine("[{0}]", string.Join(", ", newArray));
		Console.WriteLine("[{0}]", string.Join(", ", newArray1));
		Console.WriteLine("[{0}]", string.Join(", ", newArray2));
		Console.WriteLine("[{0}]", string.Join(", ", newArray3));
		Console.WriteLine("[{0}]", string.Join(", ", newArray4));
		Console.WriteLine("[{0}]", string.Join(", ", newArray5));
		Console.WriteLine("[{0}]", string.Join(", ", newArray6));
	}

	static int[] ProductOfOthersInArray(int[] array) {
		
		int length = array.Length;
		int[] newArray = new int[length];
		for (int i = 0; i < length; i++) {
			int product = 1;
			for (int j = 0; j < length; j++) {
				if (j == i) continue;
				product *= array[j];
			}
			newArray[i] = product;
		}
		return newArray;
	}
}