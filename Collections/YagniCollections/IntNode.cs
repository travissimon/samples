using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YagniCollections {
	// A node in a singly linked list
	public sealed class IntNode {
		private IntNode next;
		private int nodeValue;

		public IntNode(int intValue) {
			nodeValue = intValue;
		}

		/// <summary>
		/// Gets/sets the value for this node
		/// </summary>
		public int Value {
			get { return nodeValue; }
			set { nodeValue = value; }
		}

		/// <summary>
		/// The next node in the list
		/// </summary>
		public IntNode Next {
			get { return next; }
			internal set { next = value; }
		}

		public bool HasNext {
			get { return Next != null; }
		}
	}
}
