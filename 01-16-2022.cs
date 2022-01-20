using System;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Facebook.

	// Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.

	// Questions to ask:
	// 1. Where is the stream coming from?
	// 2. What are the elements in the stream? (strings, objects, numbers, etc.)
	// 3. Is the stream passed as an argument to the function, or does the function get the stream internally?
	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		Console.WriteLine(RandomStreamElement());
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	static int RandomStreamElement()
	{
		Random random = new Random();
		int iterations = 10000000; // arbitary size of the stream (won't be used to get the random number) (this will be unknown in real world situation)
		int randomStreamIndex = 0, i = 0;
		bool streaming = true;
		while (streaming)
		{
			randomStreamIndex = random.Next(0, i + 1); // get a random number between 0 and current count
			streaming = i < iterations; // if the stream is still streaming, continue
			i++;
		}
		return randomStreamIndex;
	}
}