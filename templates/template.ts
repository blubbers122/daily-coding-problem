'use strict';

import { performance } from 'perf_hooks';

class DailyCodingProblem {
  main = (): void => {
		const startTime = performance.now();
		this.functionName();
		const endTime = performance.now();
		console.log(`Execution time: ${endTime - startTime} ms`);
	};

	functionName = () => {
	
	};
}

new DailyCodingProblem().main();