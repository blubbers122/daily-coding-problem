using System;
class DailyCodingProblem
{
// [Hard]
// 	Good morning! Here's your coding interview problem for today.

// This problem was asked by Google.

// An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. 
// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.

// If using a language that has no pointers (such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
	static void Main(string[] args)
	{
		XORLinkedList list = new XORLinkedList();
		list.Add(1);
		Console.WriteLine(list.Get(0).value);
	}

	class XORLinkedList {
		Node head;
		Node tail;
		struct Node {
			public int both;
			public int value;
			Node next;
			Node prev;
		}
		// Adds a node to the end of the list.
		public void Add(int value) {
			Node node = new Node();
			node.value = value;
			if (head == null) {
				head = node;
				tail = node;
			}
			else {
				node.both = head.both ^ tail.both;
				tail.both = tail.both ^ node.both;
				head.both = head.both ^ node.both;
				tail = node;
			}

		}

		public Node Get(int index) {
			Node node = head;
			for (int i = 0; i < index; i++) {
				node = node.both ^ node.next.both;
			}
			return node;
		}
	}
}