using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities {

	/// <summary>
	/// Reverses the words in a sentance.
	/// </summary>
	/// <remarks>
	/// This class will generally handle inter-word punctuation correctly
	/// in English, but it will fail for some locales that use spaces as inter-word punctation (i.e. en-Fr
	/// uses spaces to sepate thousands in numbers, such as '1 234,50 €')
	/// </remarks>
	public class WordReverser {
		StringParser sp = new StringParser();
		Stack<char> characterStack = new Stack<char>();

		private string inputString;
		public string Input {
			get { return inputString; }
			set {
				inputString = value;
				sp.SetData(inputString);
			}
		}

		public string GetReversedWords() {
			StringBuilder sb = new StringBuilder(inputString.Length);
			while (sp.HasMoreData()) {
				if (Char.IsLetterOrDigit(sp.PeekChar())) {
					// normal words, these are to be reversed
					PushCharactersUntilEndOfWord();

					// reverse word by popping the letters
					while (characterStack.Count > 0)
						sb.Append(characterStack.Pop());

				} else {
					// catch all for punctuation, etc
					sb.Append(sp.NextChar());
				}
			}

			return sb.ToString();
		}

		public void PushCharactersUntilEndOfWord() {
			while (sp.HasMoreData() && NextCharacterIsPartOfWord()) {
				characterStack.Push(sp.NextChar());
			}
		}

		public bool NextCharacterIsPartOfWord() {
			char nextChar = sp.PeekChar();
			if (Char.IsWhiteSpace(nextChar))
				return false;
			if (Char.IsPunctuation(nextChar) || Char.IsSymbol(nextChar))
				// Punctuation is part of word if following char is not EOF and not whitespace (think hyphen)
				return !(Char.IsWhiteSpace(sp.PeekChar(1)) ||  sp.PeekChar(1) == default(char));

			return true;
		}
	}
}
