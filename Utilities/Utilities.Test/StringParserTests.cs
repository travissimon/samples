using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Utilities.Test {
    /// <summary>
    /// Test cases for the string parser class
    /// </summary>
	public class StringParserTests {
		private const String TEST_STRING = "Hiya.";
		private const String WHITESPACE_STRING = " \t\t\r\n Hi.";

		[Fact]
		public void Hookup() {
			Assert.True(true, "Hookup failed - the end is nigh");
		}

		[Fact]
		public void TestNextChar() {
			StringParser sp = new StringParser(TEST_STRING);

			Assert.Equal('H', sp.NextChar());
			Assert.True(sp.HasMoreData());
			Assert.Equal('i', sp.NextChar());
			Assert.True(sp.HasMoreData());
			Assert.Equal('y', sp.NextChar());
			Assert.True(sp.HasMoreData());
			Assert.Equal('a', sp.NextChar());
			Assert.True(sp.HasMoreData());
			Assert.Equal('.', sp.NextChar());

			Assert.False(sp.HasMoreData());
		}

		[Fact]
		public void TestPeekChar() {
			StringParser sp = new StringParser(TEST_STRING);

			Assert.Equal('H', sp.NextChar());
			Assert.Equal('i', sp.PeekChar());
			Assert.Equal('i', sp.PeekChar());
			Assert.Equal('i', sp.NextChar());
			Assert.Equal('y', sp.NextChar());
		}

		[Fact]
		public void TestPokeChar() {
			StringParser sp = new StringParser(TEST_STRING);

			sp.NextChar();
			sp.NextChar();
			sp.NextChar();
			Assert.Equal('a', sp.NextChar());
			sp.PokeChar();
			Assert.Equal('a', sp.NextChar());
			// Let's test poking past the start of the data
			sp.PokeChar();
			sp.PokeChar();
			sp.PokeChar();
			sp.PokeChar();
			sp.PokeChar();
			Assert.Equal('H', sp.NextChar());
		}

		[Fact]
		public void TestGetString() {
			StringParser sp = new StringParser(TEST_STRING);

			sp.NextChar();
			sp.ResetPointers();
			Assert.Equal('i', sp.NextChar());
			sp.NextChar();
			Assert.Equal("iy", sp.GetString());
			sp.NextChar();
			sp.NextChar();
			Assert.Equal("a.", sp.GetString());

			Assert.False(sp.HasMoreData());
		}

		[Fact]
		public void TestSkipWhitespace() {
			StringParser sp = new StringParser(WHITESPACE_STRING);
			sp.SkipWhiteSpace();
			Assert.Equal('H', sp.NextChar());
		}

		[Fact]
		public void TestSkipUntilEnd() {
			StringParser sp = new StringParser(WHITESPACE_STRING);
			sp.SkipWhiteSpace();
			sp.ResetPointers();
			Assert.True(sp.HasMoreData(), "HasMoreData() not as expected");
			sp.SkipToEnd();
			Assert.Equal("Hi.", sp.GetString());
			Assert.False(sp.HasMoreData());
		}

		[Fact]
		public void TestSkipUntil() {
			StringParser sp = new StringParser(TEST_STRING);
			sp.SkipUntil('.');
			Assert.True(sp.HasMoreData());
			Assert.Equal("Hiya", sp.GetString());
			Assert.Equal('.', sp.NextChar());
		}

		[Fact]
		public void TestSkipUntilString() {
			String testString = "This! is a test. Or isn't it?";

			StringParser sp = new StringParser();
			sp.SetData(testString);
			sp.SkipUntil("is");
			// Skip over the 'is' we found to see what follows
			sp.NextChar();
			sp.NextChar();

			Assert.Equal('!', sp.NextChar());
			sp.SkipUntil("is");
			// Skip over the 'is' we found to see what follows
			sp.NextChar();
			sp.NextChar();
			Assert.Equal(' ', sp.NextChar());

			sp.SetData(testString);
			sp.SkipUntil("isn'");
			// Skip over the 'is' we found to see what follows
			sp.NextChar();
			sp.NextChar();
			sp.NextChar();
			sp.NextChar();
			Assert.Equal('t', sp.NextChar());
		}

	}
}
