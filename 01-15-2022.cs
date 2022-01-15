using System;
class DailyCodingProblem
{
	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Google.

	// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.

	// Hint: The basic equation of a circle is x2 + y2 = r2.

	// Things to clarify:
	// 1. do we estimate pi with a single random number, or could we gather multiple and find the average to calculate pi?
	// 2. do we assume circles are at the origin or offset?
	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();
		Console.WriteLine(EstimatePiMonteCarlo()); // should be ~3.141
		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}


	static double EstimatePiMonteCarlo()
	{
		Random random = new Random();
		int insideCircle = 0; // number of random points inside the circle
		int iterations = 10000000; // number of iterations to run; the higher the number, the more accurate the result
		float circleRadius = 2;
		for (int i = 0; i < iterations; i++)
		{
			// Get random sample points in the upper-right quadrant
			double x = random.NextDouble() * circleRadius; // random number between 0 and circleRadius
			double y = random.NextDouble() * circleRadius; // random number between 0 and circleRadius
			// using the circle formula: x^2 + y^2 = r^2
			if (x * x + y * y <= circleRadius * circleRadius) // if the point is inside the circle
			{
				insideCircle++;
			}
		}
		double pi = 4.0 * (double)insideCircle / (double)iterations; // multiply by four since we are only sampling the upper-right quadrant. we know there is a pi / 4 chance of being inside the quadrant
		return Math.Round(pi, 3);

	}
}