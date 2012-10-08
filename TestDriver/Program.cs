using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDriver {
	/*
	 * This is a utility class to run unit tests if you don't have xUnit installed
	 */
	class Program {
		static void Main(string[] args) {
			Triangles.Test.TriangleUtilTests triangleTests = new Triangles.Test.TriangleUtilTests();
			triangleTests.CanGetTriangleUtilForTesting();
			triangleTests.TriangleUtilRecognisesEquilaterals();
			triangleTests.TriangleUtilRecognisesIsosocles();
			triangleTests.TriangleUtilRecognisesScalenes();
			triangleTests.ErrorsWithZero();
			triangleTests.ErrorsWithNegatives();
			triangleTests.ErrorsWithInvalidLengths();

			Utilities.Test.StringParserTests parserTests = new Utilities.Test.StringParserTests();
			parserTests.TestNextChar();
			parserTests.TestPeekChar();
			parserTests.TestPokeChar();
			parserTests.TestGetString();
			parserTests.TestSkipWhitespace();
			parserTests.TestSkipUntilEnd();
			parserTests.TestSkipUntil();
			parserTests.TestSkipUntilString();

			Utilities.Test.WordReverserTests reverserTests = new Utilities.Test.WordReverserTests();
			reverserTests.ReverserDoesSimpleReverse();
			reverserTests.ReverserReversesAppostrophiesAndHyphens();
			reverserTests.ReverserReversesNumbersButNotCommas();

			YagniCollections.Test.LinkedListTests listTests = new YagniCollections.Test.LinkedListTests();
			listTests.CanAddIntAndMaintainCount();
			listTests.CanIterate();
			listTests.CanIterateOverEmptyList();
			listTests.FifthLastErrorsWithLessThanFiveElements();
			listTests.FifthLastReturnsAppropriateValues();
			listTests.FifthLastReturnsAKnownValue();

			Console.WriteLine("Press any key to close this window");
			Console.ReadKey();
		}
	}
}
