"use strict";

import { performance } from "perf_hooks";

class DailyCodingProblem_01_29_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Facebook.

  // Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).

  // For example, given the string "([])[]({})", you should return true.

  // Given the string "([)]" or "((()", you should return false.

  main = (): void => {
    const startTime = performance.now();
    console.log(this.wellBalancedBrackets("([])[]({})")); // true
    console.log(this.wellBalancedBrackets("([)]")); // false
    console.log(this.wellBalancedBrackets("((()")); // false
		console.log(this.wellBalancedBrackets('(()())')); // true
		console.log(this.wellBalancedBrackets('(()()()[]{}{[]}(((([])[]){})[[]()]))'));// true
		console.log(this.wellBalancedBrackets('(()()()[]{}{[]}(((([]))[]){})[[]()]))'));// false
		console.log(this.wellBalancedBrackets(`class A {
			constructor() {
				this.name = 'John';
				this.age = 30;
			}

			getName() {
				return this.name;
			}

			sayHello() {
				return 'Hello ' + this.name;
			}
		}`));// true
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

  wellBalancedBrackets = (text: string): boolean => {
    const bracketDepths: object = {
      "(": 0,
      "[": 0,
      "{": 0,
    };

		const bracketMap: object = {
			"(": ")",
			"[": "]",
			"{": "}",
		}

    let opened: string[] = [];

    for (const char of text) {
      switch (char) {
        case "(":
        case "[":
        case "{":
          bracketDepths[char]++;
          opened.push(char);
          break;
        case ")":
        case "]":
        case "}":
          const lastOpened = opened.pop();
          if (bracketMap[lastOpened] !== char) return false;
          bracketDepths[lastOpened]--;
          break;
      }
    }

    return Object.entries(bracketDepths).every(([_key, value]) => value === 0);
  };
}

new DailyCodingProblem_01_29_2022().main();
