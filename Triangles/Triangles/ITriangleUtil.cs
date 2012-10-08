using System;

namespace Triangles {
	public enum TriangleType { Scalene, Isosocles, Equilateral, Error };

	public interface ITriangleUtil {
		TriangleType GetTriangleType(int side1, int side2, int side3);
	}
}
