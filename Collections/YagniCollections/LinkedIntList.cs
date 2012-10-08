using System;
using System.Collections;
using System.Collections.Generic;

namespace YagniCollections {
	/// <summary>
	/// Single linked list of integers (by hand). In production you would use the LinkedList<T> class in System.Collections.
	/// This is an implementation that finds the 5th element in a list, using only what is needed to solve this puzzle problem
	/// (You aint gunna need it or YAGNI). An API version of a Linked List would need to be more complete.
	/// </summary>
	public sealed class LinkedIntList : IEnumerable<int> {
		private IntNode head = null;
		private IntNode tail = null;
		private int count = 0;

		/// <summary>
		/// Adds a new integer to the list
		/// </summary>
		/// <param name="intVal">The value to add to the list</param>
		public void Add(int intVal) {
			IntNode node = new IntNode(intVal);

			// is this the first element in the list?
			if (head == null) {
				head = tail = node;
				count++;
				return;
			}

			tail.Next = node;
			tail = node;
			count++;
		}

		/// <summary>
		/// Returns the number of items in the list
		/// </summary>
		public int Count {
			get { return count; }
		}

		/// <summary>
		/// Returns the fifth last element in the list, using no more than one pass through the list
		/// </summary>
		/// <returns>fifth last element in the list</returns>
		public int GetFifthLast() {
			if (Count < 5)
				throw new IndexOutOfRangeException("List must contain at least 5 elements");

			if (count == 5)
				return head.Value;

			IntNode current = head;
			for (int i = 0; i < (Count - 5); i++)
				current = current.Next;

			return current.Value;
		}

		#region Enumerator

		public IEnumerator<int> GetEnumerator() {
			return new LinkedIntListEnumerator(head);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return new LinkedIntListEnumerator(head);
		}

		// Simple enumberator implementation
		public sealed class LinkedIntListEnumerator : IEnumerator<int> {
			private IntNode head;
			private IntNode currentNode;

			internal LinkedIntListEnumerator(IntNode headNode) {
				head = headNode;
			}

			public int Current {
				get { return currentNode.Value; }
			}

			public void Dispose() {
				currentNode = null;
			}

			object IEnumerator.Current {
				get { return currentNode.Value; }
			}

			public bool MoveNext() {
				if (currentNode == null) {
					currentNode = head;
					return (currentNode != null);
				}

				if (currentNode.HasNext) {
					currentNode = currentNode.Next;
					return true;
				}

				return false;
			}

			public void Reset() {
				currentNode = null;
			}
		}

		#endregion
	}
}