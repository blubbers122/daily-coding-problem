using System;
using System.Collections;
class DailyCodingProblem
{

	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Microsoft.

	// Suppose an arithmetic expression is given as a binary tree. Each leaf is an integer and each internal node is one of '+', '−', '∗', or '/'.

	// Given the root to such a tree, write a function to evaluate it.

	// For example, given the following tree:

	//     *
	//    / \
	//   +    +
	//  / \  / \
	// 3  2  4  5
	// You should return 45, as it is (3 + 2) * (4 + 5).


	// Questions:
	// 1. Do we check that the bst is valid for our arithmetic?
	// 2. Is each new level a new set of parenthesis?
	// 3. For divide and subtract, do we perform left minus or divided by the right?


	// Note: I added new operators (not asked for in the question) for fun :)

	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();

		ArithmeticNode root1 = new ArithmeticNode(Operation.ADD,
			new ArithmeticNode(value: 1f),
			new ArithmeticNode(value: 2f)
		);
		ArithmeticNode root2 = new ArithmeticNode(Operation.SUBTRACT,
			new ArithmeticNode(value: 2f),
			new ArithmeticNode(value: 1f));
		ArithmeticNode root3 = new ArithmeticNode(Operation.MULTIPLY,
			new ArithmeticNode(value: 2.5f),
			new ArithmeticNode(value: 2f));
		ArithmeticNode root4 = new ArithmeticNode(Operation.DIVIDE,
			new ArithmeticNode(value: 2f),
			new ArithmeticNode(value: 2f));
		ArithmeticNode root5 = new ArithmeticNode(
			Operation.MULTIPLY,
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 3f),
				new ArithmeticNode(value: 2f)
			),
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 4f),
				new ArithmeticNode(value: 5f)
			)
		);
		ArithmeticNode root6 = new ArithmeticNode(
			Operation.DIVIDE,
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 20f),
				new ArithmeticNode(value: 5f)
			),
			new ArithmeticNode(
				Operation.SUBTRACT,
				new ArithmeticNode(value: 15f),
				new ArithmeticNode(
					Operation.MULTIPLY,
					new ArithmeticNode(value: 5f),
					new ArithmeticNode(value: 2f)
					)
			)
		);
		ArithmeticNode root7 = new ArithmeticNode(
			Operation.EXPONENT,
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 2f),
				new ArithmeticNode(value: 2f)
			),
			new ArithmeticNode(
				Operation.SUBTRACT,
				new ArithmeticNode(value: 5f),
				new ArithmeticNode(value: 2f)
			)
		);
		ArithmeticNode root8 = new ArithmeticNode(
			Operation.MODULO,
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 2f),
				new ArithmeticNode(value: 2f)
			),
			new ArithmeticNode(
				Operation.SUBTRACT,
				new ArithmeticNode(value: 5f),
				new ArithmeticNode(value: 2f)
			)
		);
		ArithmeticNode root9 = new ArithmeticNode(
			Operation.FLOOR_DIVIDE,
			new ArithmeticNode(
				Operation.ADD,
				new ArithmeticNode(value: 3f),
				new ArithmeticNode(value: 2f)
			),
			new ArithmeticNode(
				Operation.SUBTRACT,
				new ArithmeticNode(value: 4f),
				new ArithmeticNode(value: 2f)
			)
		);

		Console.WriteLine(EvaluateArithmeticBST(root1)); // Should be 3
		Console.WriteLine(EvaluateArithmeticBST(root2)); // Should be 1
		Console.WriteLine(EvaluateArithmeticBST(root3)); // Should be 5
		Console.WriteLine(EvaluateArithmeticBST(root4)); // Should be 1
		Console.WriteLine(EvaluateArithmeticBST(root5)); // Should be 45 --> (3 + 2) * (4 + 5)
		Console.WriteLine(EvaluateArithmeticBST(root6)); // Should be (20 + 5) / (15 - (5 * 2)) == 5
		Console.WriteLine(EvaluateArithmeticBST(root7)); // Should be (2 + 2) ^ (5 - 2) == 4^3 == 64
		Console.WriteLine(EvaluateArithmeticBST(root8)); // Should be (2 + 2) % (5 - 2) == 4 mod 3 == 1
		Console.WriteLine(EvaluateArithmeticBST(root9)); // Should be (3 + 2) / (4 - 2) == 5 // 2 == 2

		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}

	enum Operation
	{
		NONE,
		ADD,
		SUBTRACT,
		MULTIPLY,
		DIVIDE,
		EXPONENT,
		MODULO,
		FLOOR_DIVIDE
	}

	static float EvaluateArithmeticBST(ArithmeticNode node)
	{
		switch (node.operation)
		{
			case Operation.ADD:
				return EvaluateArithmeticBST(node.left) + EvaluateArithmeticBST(node.right);
			case Operation.SUBTRACT:
				return EvaluateArithmeticBST(node.left) - EvaluateArithmeticBST(node.right);
			case Operation.MULTIPLY:
				return EvaluateArithmeticBST(node.left) * EvaluateArithmeticBST(node.right);
			case Operation.DIVIDE:
				// Could put a check here to make sure the right is not 0
				return EvaluateArithmeticBST(node.left) / EvaluateArithmeticBST(node.right);
			case Operation.EXPONENT:
				return (float)Math.Pow(EvaluateArithmeticBST(node.left), EvaluateArithmeticBST(node.right));
			case Operation.MODULO:
				// Could put a check here to make sure the right is not 0
				return EvaluateArithmeticBST(node.left) % EvaluateArithmeticBST(node.right);
			case Operation.FLOOR_DIVIDE:
				// Could put a check here to make sure the right is not 0
				return (float)Math.Floor(EvaluateArithmeticBST(node.left) / EvaluateArithmeticBST(node.right));
			default: // means we reached a leaf
				return (float)node.value;

		}
	}

	class ArithmeticNode
	{

		public ArithmeticNode(Operation operation = Operation.NONE, ArithmeticNode left = null, ArithmeticNode right = null, float value = 0)
		{
			this.operation = operation;
			this.value = value;
			this.left = left;
			this.right = right;
		}


		public Operation operation;
		public float value;
		public ArithmeticNode left;
		public ArithmeticNode right;
	}

}