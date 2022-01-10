using System;
class DailyCodingProblem
{

	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Google.

	// A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.

	// Given the root to a binary tree, count the number of unival subtrees.

	// For example, the following tree has 5 unival subtrees:

	//    0
	//   / \
	//  1   0
	//     / \
	//    1   0
	//   / \
	//  1   1

	static void Main(string[] args)
	{
		//       1
		//			/ \
		//			1   1
		Node root = new Node(1, new Node(1), new Node(1)); // should be 3

		//			 1
		//			/ \
		//			2   2
		Node root2 = new Node(1, new Node(2), new Node(2)); // should be 2

		//			 1
		//			/ \
		//		 1   1
		//		/ 
		//	 1   
		Node root3 = new Node(1, new Node(1, new Node(1)), new Node(1)); // should be 4

		//			 1
		//			/ \
		//		 1   1
		//		/ \  / \
		//	 1   2 2  2
		Node root4 = new Node(1, new Node(1, new Node(1), new Node(2)), new Node(1, new Node(2), new Node(2))); // should be 4 (top 1, bottom left 1, and the two 2's on the right branch are unival)

		//			 2
		//			/ \
		//		 1   1 
		Node root5 = new Node(2, new Node(1), new Node(1)); // should be 2

		Console.WriteLine(CountUniValSubTrees(root));
		Console.WriteLine(CountUniValSubTrees(root2));
		Console.WriteLine(CountUniValSubTrees(root3));
		Console.WriteLine(CountUniValSubTrees(root4));
		Console.WriteLine(CountUniValSubTrees(root5));
		Console.WriteLine(CountUniValSubTrees(null));
	}

	static int CountUniValSubTrees(Node node)
	{
		if (node == null) return 0;

		int leftCount = CountUniValSubTrees(node.left);
		int rightCount = CountUniValSubTrees(node.right);
		return leftCount + rightCount + (IsUniVal(node) ? 1 : 0); // if the current node is unival, add 1 to the count
	}

	static bool IsUniVal(Node node)
	{
		return IsUniValHelper(node, node.value);
	}

	static bool IsUniValHelper(Node node, int parentValue)
	{
		if (node == null) return true; // if we've reached a leaf without finding a mismatch, we're unival

		if (node.value == parentValue) // if the current node's value is equal to the parent's value, check the left and right nodes for the same value
		{
			return IsUniValHelper(node.left, parentValue) && IsUniValHelper(node.right, parentValue); // if the left and right subtrees are unival recursively, return true
		}
		return false; // if the current node's value is not the same as the parent's value, then it's not unival
	}

	class Node
	{
		public Node(int value, Node left = null, Node right = null)
		{
			this.value = value;
			this.left = left;
			this.right = right;
		}
		public int value;
		public Node left;
		public Node right;
	}
}