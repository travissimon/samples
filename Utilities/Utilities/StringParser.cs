using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities {
    /// <summary>
    /// Low-level string parsing utility class.
    /// </summary>
	public class StringParser {
		private char[] data = new char[0];
		private int cp = 0, np = 0;

		public StringParser() {
		}

		/// <summary>
		/// Returns the current character in the stream. Included 
		/// for testing, although it is expected that NextChar()
		/// will be used in most situations.
		/// </summary>
		/// <returns>position of np</returns>
		public int CurrentCharacter() {
			return np;
		}

		/// <summary>
		/// Constructor that accepts the data to be parsed
		/// </summary>
		/// <param name="data">String content to be parsed</param>
		public StringParser(String data) {
			SetData(data);
		}

		/// <summary>
		/// Sets the data to be parsed, and resets the pointers
		/// to the beginning of the content
		/// </summary>
		/// <param name="data">String content to be parsed</param>
		public void SetData(String data) {
			this.data = data.ToCharArray();
			np = 0;
			ResetPointers();
		}

		/// <summary>
		/// Sets the current position as the starting point for the
		/// next call to GetString()
		/// </summary>
		public void ResetPointers() {
			cp = np;
		}

		/// <summary>
		/// Check for overrunning the bounds of the data string
		/// </summary>
		/// <returns>true if we have more data to parse, false otherwise</returns>
		public bool HasMoreData() {
			return np < data.Length;
		}

		/// <summary>
		/// Returns the next character and increments the current position
		/// </summary>
		/// <returns>the next character</returns>
		public char NextChar() {
			return (HasMoreData() ? data[np++] : new char());
		}

		/// <summary>
		/// Returns the next character but does not increment the current position
		/// </summary>
		/// <returns>the next character</returns>
		public char PeekChar() {
			return PeekChar(0);
		}

		public char PeekChar(int charCount) {
			if ((np + charCount) >= data.Length) return new char();

			return data[np + charCount];
		}

		/// <summary>
		/// Moves the current position forward without resetting the stream pointers.
		/// </summary>
		/// <param name="charCount">Number of characters to move forward.</param>
		public void MoveForward(int charCount) {
			if ((np + charCount) >= data.Length - 1)
				SkipToEnd();
			else
				np += charCount;
		}

		/// <summary>
		/// Pushes the most recent character returned from nextChar() back onto the stack
		/// </summary>
		public void PokeChar() {
			if (np > 0) np--;
		}

		/// <summary>
		/// Returns the string between the start and end pointers and resets the current position.
		/// </summary>
		/// <returns>Current string value</returns>
		public String GetString() {
			StringBuilder sb = new StringBuilder(np - cp);
			for (int i = cp; i < np; i++) {
				sb.Append(data[i]);
			}
			ResetPointers();
			return sb.ToString();
		}

		/// <summary>
		/// Skips all whitespace from the current position
		/// </summary>
		public void SkipWhiteSpace() {
			if (!HasMoreData()) return;
			char c;
			for (c = NextChar(); Char.IsWhiteSpace(c) && HasMoreData(); c = NextChar()) ;
			if (HasMoreData() || !Char.IsWhiteSpace(c)) PokeChar();
		}

		/// <summary>
		/// Skips characters until the search character is found.
		/// </summary>
		/// <param name="c">character to search for</param>
		public void SkipUntil(Char c) {
			if (!HasMoreData()) return;
			char nc = NextChar();
			for (; nc != c && HasMoreData(); nc = NextChar()) ;
			if (nc == c) PokeChar();
		}

		/// <summary>
		/// Skips forward the specified amount
		/// </summary>
		/// <param name="charsToSkip">Number of characters to skip</param>
		public void Skip(int charsToSkip) {
			if (!HasMoreData()) return;
			np += charsToSkip;
			ResetPointers();
		}

		/// <summary>
		/// Skips until it encounters search string or end of line.
		/// This method is a bit more intensive than the other methods, 
		/// so avoid using it if possible.
		/// </summary>
		/// <param name="s">String to search for</param>
		/// <returns>true if string is found</returns>
		public bool SkipUntil(String s) {
			if (string.IsNullOrEmpty(s)) return false;
			if (!HasMoreData()) return false;
			char[] searchChars = s.ToCharArray();
			bool continueSearching = true;
			bool found = false;
			SkipUntil(searchChars[0]);
			while (HasMoreData() && !found) {
				continueSearching = true;
				int i = 0;
				for (; i < searchChars.Length; i++) {
					continueSearching &= searchChars[i] == PeekChar(i);
					if (!continueSearching) break;
				}
				if (i == searchChars.Length && continueSearching) {
					found = true;
					break;
				}
				NextChar();
				SkipUntil(searchChars[0]);
			}
			return found;
		}

		/// <summary>
		/// Skips all characters until the end of the string
		/// </summary>
		public void SkipToEnd() {
			np = data.Length;
		}
	}
}
