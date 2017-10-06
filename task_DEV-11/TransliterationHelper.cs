using System;
using System.Collections.Generic;

namespace task_DEV_11
{
  public class TransliterationHelper
  {
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
      // If it is not, it will get an exception further.
      // Same for the rus string.
      // Choose the way to transliterate and do transliteration.
      return isInputLatin
        ? TransliterateFromLatinToRus(input, fromRusToLatinAlphabet, fromLatinToRusAlphabet)
        : TransliterateFromRusToLatin(input, fromRusToLatinAlphabet, fromLatinToRusAlphabet);
    }

    public string TransliterateFromRusToLatin(string input, Dictionary<string, string> fromRusToLatinAlphabet,
      Dictionary<string, string> fromLatinToRusAlphabet)
    {
      string transliteratedInput = null;
      foreach (var value in fromLatinToRusAlphabet.Keys)
      {
        if (input.Contains(value))
        {
          throw new Exception();
        }
      }

      foreach (var value in fromRusToLatinAlphabet.Keys)
      {
        transliteratedInput = input.Replace(value, fromRusToLatinAlphabet[value]);
      }
      return transliteratedInput;
    }

    //
    public string TransliterateFromLatinToRus(string input, Dictionary<string, string> fromRusToLatinAlphabet,
      Dictionary<string, string> fromLatinToRusAlphabet)
    {
      string transliteratedInput = null;
      foreach (var value in fromRusToLatinAlphabet.Keys)
      {
        if (input.Contains(value))
        {
          throw new Exception();
        }
      }

      foreach (var value in fromLatinToRusAlphabet.Keys)
      {
        transliteratedInput = input.Replace(value, fromLatinToRusAlphabet[value]);
      }
      return transliteratedInput;
    }
  }
}
