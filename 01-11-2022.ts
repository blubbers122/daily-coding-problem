class DailyCodingProblem_01_11_2022 {
  // 	Good morning! Here's your coding interview problem for today.

  // This problem was asked by Apple.

  // Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
  main = (): void => {
		this.jobScheduler(this.job1, 1000); // run job1 function every second
		this.jobScheduler(this.job2, 500); // run job2 function every half second
	};

	job1 = (): void => {
		console.log("job1 ran");
	};
	job2 = (): void => {
		console.log("job2 ran");
	}

  jobScheduler = (f: Function, n: number): void => {
		setTimeout(f,n);
	};
}

new DailyCodingProblem_01_11_2022().main();