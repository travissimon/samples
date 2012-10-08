using System;
using System.IO;
using System.Text;
using Triangles;
using Xunit;

namespace Triangles.Test {
	/// <summary>
	/// Tests a triangle util to ensure proper functioning
	/// </summary>
	public class TriangleUtilTests {

		// Change this method test your implementation
		private ITriangleUtil GetTriangleUtil() {
			return new TriangleUtil();
		}

		[Fact]
		public void Hookup() {
			Assert.True(true, "Hookup failed");
		}

		[Fact]
		public void CanGetTriangleUtilForTesting() {
			Assert.NotNull(GetTriangleUtil());
		}

		[Fact]
		public void TriangleUtilRecognisesEquilaterals() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Equilateral, util.GetTriangleType(1, 1, 1));
			Assert.Equal(TriangleType.Equilateral, util.GetTriangleType(27, 27, 27));
			Assert.Equal(TriangleType.Equilateral, util.GetTriangleType(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue));
		}

		[Fact]
		public void TriangleUtilRecognisesIsosocles() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Isosocles, util.GetTriangleType(2, 2, 3));
			Assert.Equal(TriangleType.Isosocles, util.GetTriangleType(425, 425, 584));
			Assert.Equal(TriangleType.Isosocles, util.GetTriangleType(425, 584, 425));
			Assert.Equal(TriangleType.Isosocles, util.GetTriangleType(584, 425, 425));
			Assert.Equal(TriangleType.Isosocles, util.GetTriangleType(Int32.MaxValue - 1, Int32.MaxValue - 1, Int32.MaxValue));
		}

		[Fact]
		public void TriangleUtilRecognisesScalenes() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Scalene, util.GetTriangleType(2, 3, 4));
			Assert.Equal(TriangleType.Scalene, util.GetTriangleType(789, 3348, 3952));
			Assert.Equal(TriangleType.Scalene, util.GetTriangleType(3952, 789, 3348));
			Assert.Equal(TriangleType.Scalene, util.GetTriangleType(3348, 3952, 789));
			Assert.Equal(TriangleType.Scalene, util.GetTriangleType(Int32.MaxValue - 2, Int32.MaxValue - 1, Int32.MaxValue));
		}

		[Fact]
		public void ErrorsWithZero() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Error, util.GetTriangleType(0, 0, 0));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(0, 587, 254));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(581, 0, 594562));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(8416, 25185, 0));
		}

		[Fact]
		public void ErrorsWithNegatives() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Error, util.GetTriangleType(-10, -10, -10));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(Int32.MinValue, Int32.MinValue, Int32.MinValue));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(-39, 587, 254));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(581, Int32.MinValue, 594562));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(8416, 25185, -2394));
		}

		[Fact]
		public void ErrorsWithInvalidLengths() {
			ITriangleUtil util = GetTriangleUtil();
			Assert.Equal(TriangleType.Error, util.GetTriangleType(1, 1, 4));
			Assert.Equal(TriangleType.Error, util.GetTriangleType(32340, 2390, 1993));
		}

	}
}
