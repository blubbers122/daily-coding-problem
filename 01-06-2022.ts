// This problem was asked by Jane Street.

// cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.

// Given this implementation of cons:

// def cons(a, b):
//     def pair(f):
//         return f(a, b)
//     return pair
// Implement car and cdr.

const cons = (a:number, b:number) => {
	const pair = (f:Function) => {
		return f(a, b);
	};
	return pair;
};

// returns first of pair
const car = (f:Function) => {
	const pair = f((a:number, b:number) => {
		return a;
	});
	return pair;
};

// returns last of pair
const cdr = (f:Function) => {
	const pair = f((a:number, b:number) => {
		return b;
	});
	return pair;
};

console.log(car(cons(3, 4))); // should be 3
console.log(cdr(cons(3, 4))); // should be 4
