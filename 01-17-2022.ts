'use strict';

import { performance } from 'perf_hooks';

class DailyCodingProblem_01_17_2022 {
  main = (): void => {
		const startTime = performance.now();
		this.MyFunction_01_17_2022();
		const endTime = performance.now();
		console.log(`Execution time: ${endTime - startTime} ms`);
	};

	MyFunction_01_17_2022 = () => {
	
	};
}

new DailyCodingProblem_01_17_2022().main();