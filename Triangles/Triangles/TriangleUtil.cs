using System;

namespace Triangles {
	public class TriangleUtil : ITriangleUtil {

		/// <summary>
		/// Checks three lengths to determine the type (if any) of triangle
		/// that would be formed.
		/// </summary>
		/// <param name="side1">The length of the first triangle side</param>
		/// <param name="side2">The length of the second triangle side</param>
		/// <param name="side3">The length of the third triangle side</param>
		/// <returns>The appropriate TriangleType (i.e. Isosocles, Scalene or Equilateral)</returns>
		public TriangleType GetTriangleType(int side1, int side2, int side3) {
			if (!ValidTriangleLengths(side1, side2, side3))
				return TriangleType.Error;

			int matchingSides = CountMatchingLengths(side1, side2, side3);

			if (matchingSides == 3) {
				return TriangleType.Equilateral;
			} else if (matchingSides == 2) {
				return TriangleType.Isosocles;
			}

			return TriangleType.Scalene;
		}

		private static bool ValidTriangleLengths(int side1, int side2, int side3) {
			if (side1 < 1 || side2 < 1 || side3 < 1)
				return false;

			// test: smallest + next smallest <= longest
			int[] sides = { side1, side2, side3 };
			Array.Sort(sides);

			long tmp = (long)sides[0] + sides[1];

			if ((long)sides[0] + sides[1] <= sides[2])
				return false;

			return true;
		}

		private static int CountMatchingLengths(int a, int b, int c) {
			if (a == b && b == c)
				return 3;
			if (a == b || b == c || a == c)
				return 2;

			return 0;
		}
	}
}
