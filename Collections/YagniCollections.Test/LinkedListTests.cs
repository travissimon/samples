using System;
using Xunit;

namespace YagniCollections.Test {
	public class LinkedListTests {

		[Fact]
		public void UnitTestsHookedUp() {
			Assert.True(true, "True is false, the end is nigh");
		}

		[Fact]
		public void CanAddIntAndMaintainCount() {
			LinkedIntList intList = new LinkedIntList();
			Assert.Equal(0, intList.Count);
			intList.Add(1);
			Assert.Equal(1, intList.Count);
			intList.Add(2);
			Assert.Equal(2, intList.Count);
		}

		[Fact]
		public void CanIterate() {
			int[] testInts = new int[] { 0, 2, 3, 1243, -13 };
			LinkedIntList intList = new LinkedIntList();

			for (int i = 0; i < testInts.Length; i++) {
				Assert.Equal(i, intList.Count);
				intList.Add(testInts[i]);
			}

			int[] resultInts = new int[intList.Count];
			int index = 0;
			// iterate and save values
			foreach (int intValue in intList) {
				resultInts[index++] = intValue;
			}

			// Compare the two results
			Assert.Equal(testInts.Length, resultInts.Length);
			for (int i = 0; i < testInts.Length; i++) {
				Assert.Equal(testInts[i], resultInts[i]);
			}
		}

		[Fact]
		public void CanIterateOverEmptyList() {
			LinkedIntList list = new LinkedIntList();
			Assert.Empty(list);
			foreach (var value in list) {
				throw new Exception("There should be no values in an empty list");
			}
		}

		[Fact]
		public void FifthLastErrorsWithLessThanFiveElements() {
			LinkedIntList list = new LinkedIntList();
			Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
			list.Add(1);
			Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
			list.Add(2);
			Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
			list.Add(3);
			Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
			list.Add(4);
			Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
			list.Add(5);
			Assert.DoesNotThrow((() => { list.GetFifthLast(); }));
			list.Add(6);
			Assert.DoesNotThrow((() => { list.GetFifthLast(); }));
			list.Add(7);
		}

		[Fact]
		public void FifthLastReturnsAppropriateValues() {
			LinkedIntList list = new LinkedIntList();

			int initialListCount = 5;
			// seed the list with values 1 - 5
			for (int i = 1; i <= initialListCount; i++) {
				Assert.Throws(typeof(IndexOutOfRangeException), (() => { list.GetFifthLast(); }));
				list.Add(i);
			}

			// Check values as we add more
			for (int i = 1; i <= 5; i++) {
				Assert.Equal(i, list.GetFifthLast());
				list.Add(i + initialListCount);
			}
		}

		[Fact]
		public void FifthLastReturnsAKnownValue() {
			// this is just a final sanity test

			LinkedIntList list = new LinkedIntList();
			list.Add(134);
			list.Add(5823);
			list.Add(-12);
			list.Add(0);
			list.Add(132);
			list.Add(5209);

			Assert.Equal(5823, list.GetFifthLast());
			list.Add(1305);
			Assert.Equal(-12, list.GetFifthLast());
		}
	}
}
