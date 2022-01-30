using System;
class DailyCodingProblem
{

	// 	Good morning! Here's your coding interview problem for today.

	// This problem was asked by Google.

	// Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.

	// Design a binary tree node class with the following methods:

	// is_locked, which returns whether the node is locked
	// lock, which attempts to lock the node. If it cannot be locked, then it should return false. Otherwise, it should lock it and return true.
	// unlock, which unlocks the node. If it cannot be unlocked, then it should return false. Otherwise, it should unlock it and return true.
	// You may augment the node to add parent pointers or any other property you would like. You may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. Each method should run in O(h), where h is the height of the tree.

	static void Main(string[] args)
	{
		System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
		stopWatch.Start();

		// 0
		Node tree1 = new Node(null, null);

		//        0
		//			/   \
		//		 0     1
		Node tree2 = new Node(
			new Node(null, null),
			new Node(null, null)
		);
		tree2.right.isLocked = true;

		//        0
		//			/   \
		//		 0     0
	  //		/ 	  / \
	  //	 0     0   0

		Node tree3 = new Node(
			new Node(
				new Node(null, null),
				null
			),
			new Node(
				new Node(null, null),
				new Node(null, null)
			)
		);

		//        0
		//			/   \
		//		 0     0
	  //		/ 	  / \
	  //	 0     0   0
	  //				/ \
	  //			 0   0
		Node tree4 = new Node(
			new Node(
				new Node(null, null),
				null
			),
			new Node(
				new Node(
					new Node(null, null),
					new Node(null, null)
				),
				new Node(null, null)
			)
		);

		// Can't lock/unlock null node
		Console.WriteLine("Null tests");
		Console.WriteLine(BinaryTree.Lock(null)); // False
		Console.WriteLine(BinaryTree.Lock(null)); // False

		Console.WriteLine("\nTree 1");
		Console.WriteLine(BinaryTree.Lock(tree1)); // True
		Console.WriteLine(BinaryTree.UnLock(tree1)); // True
		Console.WriteLine(BinaryTree.Lock(tree1)); // True

		Console.WriteLine("\nTree 2");
		// can't lock this since we set a child node to locked
		Console.WriteLine(BinaryTree.Lock(tree2)); // False
		Console.WriteLine(tree2.isLocked); // False
		// Unlock the offending child node to be able to lock tree2
		Console.WriteLine(BinaryTree.UnLock(tree2.right)); // True
		Console.WriteLine(tree2.right.isLocked); // false
		Console.WriteLine(BinaryTree.Lock(tree2)); // True
		Console.WriteLine(tree2.isLocked); // True

		Console.WriteLine("\nTree 3");
		Console.WriteLine(BinaryTree.Lock(tree3)); // True
		Console.WriteLine(BinaryTree.Lock(tree3.left.left)); // True
		// Can't unlock since we locked a child
		Console.WriteLine(BinaryTree.UnLock(tree3)); // False

		Console.WriteLine("\nTree 4");
		Console.WriteLine(BinaryTree.Lock(tree4)); // True
		Console.WriteLine(BinaryTree.UnLock(tree4)); // True
		Console.WriteLine(BinaryTree.Lock(tree4.right.left.left)); // True
		Console.WriteLine(BinaryTree.Lock(tree4)); // False
		Console.WriteLine(BinaryTree.UnLock(tree4.right.left.left)); // True


		stopWatch.Stop();
		Console.WriteLine($"Execution Time: {stopWatch.ElapsedMilliseconds} ms");
	}


}

static class BinaryTree
{

	public static bool Lock(Node node)
	{

		// if everything below this node is unlocked, we can lock the root
		if (CanChangeLock(node)) {
			node.isLocked = true;
			return true;
		}
		return false;
	}

	private static bool CanChangeLock(Node node) {
		return node != null && CanChangeLockHelper(node.left) && CanChangeLockHelper(node.right);
		
	}

	private static bool CanChangeLockHelper(Node node) {
		return node == null || (!node.isLocked && CanChangeLockHelper(node.left) && CanChangeLockHelper(node.right));
	}

	public static bool UnLock(Node node)
	{

		// if everything below this node is unlocked, we can unlock the root
		if (CanChangeLock(node)) {
			node.isLocked = false;
			return true;
		}
		return false;
	}
}

class Node
{

	public Node left;
	public Node right;
	public bool isLocked;

	public Node(Node left = null, Node right = null)
	{
		this.isLocked = false;
		this.left = left;
		this.right = right;
	}

}