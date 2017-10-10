using System;
using System.Collections.Generic;

namespace task_DEV_11
{
  // Class that provides methods to imlement transliteration of the string from latin to rus and from rus to latin.
  public class TransliterationHelper
  {
    // Transliterate the string, choosing right variant: from rus to latin or from latin to rus.
    public string Transliterate(string input, Dictionary<string, string> fromRusToLatinAlphabet,
      Dictionary<string, string> fromLatinToRusAlphabet)
    {
      // Check first symbol of the input string if it is latin or rus.
      bool isInputLatin = true;
      foreach (var value in fromRusToLatinAlphabet.Keys)
      {
        if (input[0].ToString() == value)
        {
          isInputLatin = false;
          break;
        }
      }
      // Now will think that the whole input string is latin, if the first symbol is latin.
      // If the string will contain non-latin formants, it will get an exception further.
      // Same for the rus string.
      // Then choose the way to transliterate and do transliteration.
      return isInputLatin
        ? TransliterateFromLatinToRus(input, fromRusToLatinAlphabet, fromLatinToRusAlphabet)
        : TransliterateFromRusToLatin(input, fromRusToLatinAlphabet, fromLatinToRusAlphabet);
    }

    // Transliterate string from rus to latin.
    public string TransliterateFromRusToLatin(string input, Dictionary<string, string> fromRusToLatinAlphabet,
      Dictionary<string, string> fromLatinToRusAlphabet)
    {
      // If the input string contains at least one formant of latin alphabet the exception is coming.
      string transliteratedInput = input;
      foreach (var value in fromLatinToRusAlphabet.Keys)
      {
        if (input.Contains(value))
        {
          throw new ArgumentException();
        }
      }

      // Do transliteration by replacing all formants of rus alphabet with the latin formants.
      foreach (var value in fromRusToLatinAlphabet.Keys)
      {
        transliteratedInput = transliteratedInput.Replace(value, fromRusToLatinAlphabet[value]);
      }

      return transliteratedInput;
    }

    // Transliterate string from latin to rus.
    public string TransliterateFromLatinToRus(string input, Dictionary<string, string> fromRusToLatinAlphabet,
      Dictionary<string, string> fromLatinToRusAlphabet)
    {
      // If the input string contains at least one formant of rus alphabet the exception is coming.
      string transliteratedInput = input;
      foreach (var value in fromRusToLatinAlphabet.Keys)
      {
        if (input.Contains(value))
        {
          throw new ArgumentException();
        }
      }

      // Do transliteration by replacing all formants of latin alphabet with the rus formants.
      foreach (var value in fromLatinToRusAlphabet.Keys)
      {
        transliteratedInput = transliteratedInput.Replace(value, fromLatinToRusAlphabet[value]);
      }
      return transliteratedInput;
    }
  }
}
