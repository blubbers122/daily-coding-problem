using System;
using System.Collections.Generic;
class DailyCodingProblem
{
	// 	This problem was asked by Google.

	// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.

	// For example, given the following Node class

	// class Node:
	//     def __init__(self, val, left=None, right=None):
	//         self.val = val
	//         self.left = left
	//         self.right = right
	// The following test should pass:

	// node = Node('root', Node('left', Node('left.left')), Node('right'))
	// assert deserialize(serialize(node)).left.left.val == 'left.left'
	static void Main(string[] args)
	{
		//     o
		//   /   \
		//  o     o
		Node node = new Node("root", new Node("left"), new Node("right"));

		//     o
		//   /   \
		//  o     o
		// / 
		//o       

		Node node2 = new Node("root",
									new Node("left",
											new Node("left.left")
									),
									new Node("right")
								);
		Console.WriteLine(Serialize(node));
		

		Console.WriteLine();

		Node deserializedNode = Deserialize(Serialize(node));
		Console.WriteLine("right value was " + node.right.value + ", now is " + deserializedNode.right.value);
		Console.WriteLine("left value was " + node.left.value + ", now is " + deserializedNode.left.value);
		Console.WriteLine("root value was " + node.value + ", now is " + deserializedNode.value);

		Console.WriteLine();
		Console.WriteLine(Serialize(node2));
		Console.WriteLine();

		
		Node deserializedNode2 = Deserialize(Serialize(node2));
		Console.WriteLine("right value was " + node2.right.value + ", now is " + deserializedNode2.right.value);
		Console.WriteLine("left value was " + node2.left.value + ", now is " + deserializedNode2.left.value);
		Console.WriteLine("root value was " + node2.value + ", now is " + deserializedNode2.value);
		Console.WriteLine("left left value was " + node2.left.left.value + ", now is " + deserializedNode2.left.left.value);
	}

	static Node Deserialize(string serialized)
	{
		// foreach (string data in serialized.Split(' '))
		// {
		// 	Console.WriteLine(data);
		// }
		index = 0;
		return DeserializeHelper(serialized.Split(' '));
	}

	static int index = 0;

	static Node DeserializeHelper(string[] nodeValues) {
		
		if (index >= nodeValues.Length) return null;
		string value = nodeValues[index];
		index++;
		if (value == "-1") return null;
		return new Node(value, DeserializeHelper(nodeValues), DeserializeHelper(nodeValues));
	}

	static string Serialize(Node node)
	{
		if (node == null) return "-1";
		return node.value + " " + Serialize(node.left) + " " + Serialize(node.right);
	}



	class Node
	{
		public string value;
		public Node right;
		public Node left;
		public Node(string value, Node left = null, Node right = null)
		{
			this.value = value;
			this.left = left;
			this.right = right;
		}
	}
}
