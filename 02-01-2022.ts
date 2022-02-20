"use strict";

import { performance } from "perf_hooks";
import { printResults } from "./print_results";

class DailyCodingProblem_02_01_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Google.

  // The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other. For example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.

  // Given two strings, compute the edit distance between them.
  main = (): void => {
    const startTime = performance.now();
    printResults(
      this.editDistance("kitten", "sitting"), // 3
      this.editDistance("itten", "kitten"), // 1
      this.editDistance("kitte", "kitten"),
      this.editDistance("a", "apple"), // 4
      this.editDistance("a", "banana"), // 5
      this.editDistance("a", "")
    );
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

  editDistance = (originalStr: string, newStr: string): number => {
    let distance = Math.abs(originalStr.length - newStr.length);

    let i, j;
    while (i < originalStr.length && j < newStr.length) {
      if (originalStr[i] == newStr[j]) continue;
      
      i++;
    }

    return distance;
  };
}

new DailyCodingProblem_02_01_2022().main();
