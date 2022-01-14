"use strict";

import { performance } from "perf_hooks";

class DailyCodingProblem_01_13_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Amazon.

  // There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.

  // For example, if N is 4, then there are 5 unique ways:

  // 1, 1, 1, 1
  // 2, 1, 1
  // 1, 2, 1
  // 1, 1, 2
  // 2, 2
  // What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.


	// Important Questions to Ask:
	// 1. Can you climb the stairs in any order?
	// 2. Recursive or Iterative?

  main = (): void => {
    const startTime = performance.now();
    console.log(this.uniqueLadderPaths(4)); // should be 5 [1,1,1,1] [2,1,1] [1,2,1] [1,1,2] [2,2]
		console.log(this.uniqueLadderPathsForStepsSizes(4, [1, 3, 5])); // should be 3 [1,3] [1,1,1,1] [3,1]
		console.log(this.uniqueLadderPaths(5)); // should be 8
		console.log(this.uniqueLadderPathsForStepsSizes(5, [1, 3, 5])); // should be 5 [1,1,1,1,1] [1,3,1] [1,1,3] [3,1,1] [5]
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

	// unique ladder paths for taking steps of size 1 or 2
  uniqueLadderPaths = (steps: number): number => {
    if (steps == 0) return 1;
    return (
      this.uniqueLadderPaths(steps - 1) + (steps >= 2 ? this.uniqueLadderPaths(steps - 2) : 0)
    );
  };

	// unique ladder paths for taking steps of any size
	uniqueLadderPathsForStepsSizes = (steps: number, stepSizes: number[]) => {
		if (steps == 0) return 1;
		let total = 0;
		for (const stepSize of stepSizes) {
			if (steps >= stepSize) {
				total += this.uniqueLadderPathsForStepsSizes(steps - stepSize, stepSizes);
			}
		}
		return total;
	};
}

new DailyCodingProblem_01_13_2022().main();
