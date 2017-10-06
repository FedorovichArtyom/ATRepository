using System;
using System.Collections.Generic;
using System.IO;

namespace task_DEV_11
{
  public class FileReader
  {
    public Dictionary<string, string> GetAlphabetFromFile(string filePath)
    {
      // Get alphabet from file.
      string[] alphabetFromFileFormantPairs = null;
      using (TextReader textReader = new StreamReader(filePath))
      {
        char[] delimiters = { '[', ']', '\r', '\n' };
        alphabetFromFileFormantPairs = textReader.ReadToEnd()
          .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
      }

      // Add it to the dictionary.
      var alphabet = new Dictionary<string, string>();
      foreach (var formantsMapping in alphabetFromFileFormantPairs)
      {
        char[] delimiters = { ' ', '-' };
        string[] formants = formantsMapping.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        alphabet.Add(formants[0].Replace("\"", string.Empty), formants[1].Replace("\"", string.Empty));
      }

      return alphabet;
    }

    public string GetInputStringFromFile(string filepath)
    {
      string inputString;
      using (TextReader textReader = new StreamReader(filepath))
      {
        inputString = textReader.ReadToEnd();
      }

      return inputString;
    }
  }
}
