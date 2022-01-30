"use strict";

import { performance } from "perf_hooks";

class DailyCodingProblem_01_29_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Palantir.

  // Write an algorithm to justify text. Given a sequence of words and an integer line length k, return a list of strings which represents each line, fully justified.

  // More specifically, you should have as many words as possible in each line. There should be at least one space between each word. Pad extra spaces when necessary so that each line has exactly length k. Spaces should be distributed as equally as possible, with the extra spaces, if any, distributed starting from the left.

  // If you can only fit one word on a line, then you should pad the right-hand side with spaces.

  // Each word is guaranteed not to be longer than k.

  // For example, given the list of words ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] and k = 16, you should return the following:

  // ["the  quick brown", # 1 extra space on the left
  // "fox  jumps  over", # 2 extra spaces distributed evenly
  // "the   lazy   dog"] # 4 extra spaces distributed evenly

  main = (): void => {
    const startTime = performance.now();
    console.log(this.justifyText(
      ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"],
      16
    ));
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

  justifyText = (words: string[], k: number): string[] => {
    const justified = [];
    
		let line: string = "";
		let wordsThisLine = 0;

		words.forEach(word => {
			
			wordsThisLine++;

			line += word + " ";

			if (word.length + line.length + 1 > k) {
				justified.push(line);
				line = "";
				
			}
		});

		justified.forEach

		return justified;
  };
}

new DailyCodingProblem_01_29_2022().main();
