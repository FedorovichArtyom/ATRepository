using System;
using System.Collections.Generic;
using System.IO;

namespace task_DEV_11
{
  public class FileReader
  {
    public Dictionary<string, string> GetAlphabetFromFile(string filePath)
    {
      // Get an alphabet from file.
      string[] alphabetFromFileFormantPairs = null;
      char[] delimiters = null;
      using (TextReader textReader = new StreamReader(filePath))
      {
        delimiters = new char[]{ '[', ']', '\r', '\n', '\t' };
        alphabetFromFileFormantPairs = textReader.ReadToEnd()
          .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
      }

      // Format an alphabet in the dictionary.
      var alphabet = new Dictionary<string, string>();
      foreach (var formantsMapping in alphabetFromFileFormantPairs)
      {
        delimiters = new char[]{ '-' };
        string[] formants = formantsMapping.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        alphabet.Add(formants[0].Replace("\"", string.Empty), formants[1].Replace("\"", string.Empty));
      }

      return alphabet;
    }

    // Read data from file with filePath as a string.
    public string GetInputStringFromFile(string filePath)
    {
      string inputString;
      using (TextReader textReader = new StreamReader(filePath))
      {
        inputString = textReader.ReadToEnd();
      }

      return inputString;
    }
  }
}
