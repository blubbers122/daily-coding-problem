'use strict';

import { performance } from 'perf_hooks';

// Good morning! Here's you coding interview problem for today.
// This problem was asked by Snapchat
// Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
// For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.

// Questions:
// 1. Should we validate that values are positive?

class DailyCodingProblem_01_22_2022 {
  main = (): void => {
		const startTime = performance.now();
		this.minimumRoomsRequired([[30, 75], [0, 50], [60, 150]]);
		const endTime = performance.now();
		console.log(`Execution time: ${endTime - startTime} ms`);
	};

	minimumRoomsRequired = (timeIntervals: number[][]): number => {
		let roomsRequired: number = 0;
		// const openings: number[] = []

		for (const timeInterval of timeIntervals) {
			// if (openings.length == 0) {
			// 	roomsRequired++;
			// 	openings.push()
			// }
		}

		return roomsRequired;
	};
}

new DailyCodingProblem_01_22_2022().main();