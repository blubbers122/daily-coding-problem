"use strict";

import { performance } from "perf_hooks";

class DailyCodingProblem_01_17_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Twitter.

  // You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:

  // record(order_id): adds the order_id to the log
  // get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
  // You should be as efficient with time and space as possible.

  main = (): void => {
    const startTime = performance.now();
    this.MyFunction_01_17_2022();
    const endTime = performance.now();
    console.log(`Execution time: ${endTime - startTime} ms`);
  };

  MyFunction_01_17_2022 = () => {};
}

new DailyCodingProblem_01_17_2022().main();
