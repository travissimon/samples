using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading;
using System.Globalization;

namespace Utilities.Test {
	public class WordReverserTests {

		[Fact]
		public void TestHarnessSetupCorrectly() {
			Assert.True(true, "Ack!");
		}

		[Fact]
		public void ReverserDoesSimpleReverse() {
			string s1       = "This is a test!";
			string expected = "sihT si a tset!";

			WordReverser reverser = new WordReverser();
			reverser.Input = s1;

			string actual = reverser.GetReversedWords();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ReverserReversesAppostrophiesAndHyphens() {
			WordReverser reverser = new WordReverser();

			string s1       = "It's likely to be a F-18s, isn't it?";
			string expected = "s'tI ylekil ot eb a s81-F, t'nsi ti?";
			reverser.Input = s1;

			string actual = reverser.GetReversedWords();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ReverserReversesNumbersButNotCommas() {
			WordReverser reverser = new WordReverser();
			string s1       = "A comma in 1,234 is different from in a sentence, isn't it?";
			string expected = "A ammoc ni 432,1 si tnereffid morf ni a ecnetnes, t'nsi ti?";
			reverser.Input = s1;

			string actual = reverser.GetReversedWords();
			Assert.Equal(expected, actual);
		}

	}
}
