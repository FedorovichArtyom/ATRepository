using System;
using System.IO;
using System.Collections.Generic;

namespace task_DEV_11
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] alphabetFromFile = null;
      string dataFromFile;
      string afterTransliterate;

      var fromRusToLatinAlphabet = new Dictionary<string, string>();
      var fromLatinToRusAlphabet = new Dictionary<string, string>();

      try
      {
        // Get from rus to latin alphabet from file.
        string filePath = args[0];
        using (TextReader textReader = new StreamReader(args[0]))
        {
          char[] delimiters = { '[', ']', '\r', '\n' };
          alphabetFromFile = textReader.ReadToEnd()
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        // Add it to the fromRusToLatinAlphabet dictionary.
        foreach (var value in alphabetFromFile)
        {
          char[] delimiters = { ' ', '-' };
          string[] formants = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
          fromRusToLatinAlphabet.Add(formants[0], formants[1]);
        }

        // Get from latin to rus alphabet from file.
        filePath = args[1];
        using (TextReader textReader = new StreamReader(args[1]))
        {
          char[] delimiters = { '[', ']', '\r', '\n' };
          alphabetFromFile = textReader.ReadToEnd()
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        // Add it to the fromLatinToRusAlphabet dictionary.
        foreach (var value in alphabetFromFile)
        {
          char[] delimiters = { ' ', '-' };
          string[] formants = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
          fromRusToLatinAlphabet.Add(formants[0], formants[1]);
        }

        // Get input string from File
        using (TextReader textReader = new StreamReader(args[1]))
        {
          dataFromFile = textReader.ReadToEnd();
        }

        // Do transliteration.
        afterTransliterate = new TransliterationHelper().Transliterate(dataFromFile, fromRusToLatinAlphabet, 
          fromLatinToRusAlphabet);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return;
      }

      // Output the result of transliteration.
      Console.WriteLine(afterTransliterate);
    }
  }
}
