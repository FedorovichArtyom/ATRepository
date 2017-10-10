using System;
using System.IO;
using System.Collections.Generic;

namespace task_DEV_11
{
  // Current program uses data from file and latin to rus, rus to latin alphabets to 
  // transliterate the string in InputData.txt
  class Program
  {
    static void Main(string[] args)
    {
      string input;
      string afterTransliterationResult;

      var fromRusToLatinAlphabet = new Dictionary<string, string>();
      var fromLatinToRusAlphabet = new Dictionary<string, string>();

      try
      {
        FileReader fileReader = new FileReader();

        // Get from rus to latin alphabet from file.
        string filePath = args[AssemblyInfo.fromRusToLatinAlphabetArgIndex];
        fromRusToLatinAlphabet = fileReader.GetAlphabetFromFile(filePath);

        // Get from latin to rus alphabet from file.
        filePath = args[AssemblyInfo.fromLatinToRusAlphabetArgIndex];
        fromLatinToRusAlphabet = fileReader.GetAlphabetFromFile(filePath);

        // Get input string from File
        filePath = args[AssemblyInfo.inputStringArgIndex];
        input = fileReader.GetInputStringFromFile(filePath);

        // Do transliteration.
        afterTransliterationResult = new TransliterationHelper().Transliterate(input, fromRusToLatinAlphabet, 
          fromLatinToRusAlphabet);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return;
      }

      // Print the input message.
      Console.WriteLine(AssemblyInfo.inputMessage);
      Console.WriteLine(input + "\n");

      // Output the result of transliteration.
      Console.WriteLine(AssemblyInfo.resultMessage);
      Console.WriteLine(afterTransliterationResult);
    }
  }
}
