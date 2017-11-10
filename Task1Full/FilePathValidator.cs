using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1Full
{
  // Provides method to check filepath if it is valid in os Windows.
  public class FilePathValidator
  {
    private readonly string filePath;
    public FilePathValidator(string filePath)
    {
      this.filePath = filePath;
    }
    // Reserved names.
    private static readonly List<string> reservedNames = new List<string>
    {
      "COM", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", 
      "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
    };

    // Validate filepath.
    public bool IsValid()
    {
      if (ContainsUnsupportedSymbols())
      {
        return false;
      }

      if (ContainsReservedNamesForFileName())
      {
        return false;
      }

      if (ContainsIllegalSymbolsInTheEnd())
      {
        return false;
      }
      if (ContainsThreeOrMoreBackslashes())
      {
        return false;
      }

      if (ContainsIllegalBackslashAndDotsCombinations())
      {
        return false;
      }

      if (ContainsIllegalTwobackslashQuestionmarkBackslashCombinations())
      {
        return false;
      }

      // If the filepath contains diskname.
      if (filePath.Contains(":"))
      {
        if (ContainsTwoOrMoreDoubleDotSymbols())
        {
          return false;
        }

        if (!IsValidDiskName())
        {
          return false;
        }
      }

      return true;
    }

    // 1. Check for unsupported symbols.
    private bool ContainsUnsupportedSymbols()
    {
      foreach (char symbol in Path.GetInvalidPathChars())
      {
        if (filePath.Contains(symbol.ToString()))
        {
          return true;
        }
      }
      return false;
    }

    // 2. Check for reserved names.
    private bool ContainsReservedNamesForFileName()
    {
      foreach (var name in reservedNames)
      {
        if (filePath.Contains(name))
        {
          char symbolAfterReservedName = filePath[filePath.LastIndexOf(name) + name.Length];
          if (symbolAfterReservedName == '.')
          {
            int dotAfterReservedNameIndex = filePath.LastIndexOf(name) + name.Length;
            if (dotAfterReservedNameIndex == filePath.LastIndexOf('.'))
            {
              int symbolBeforeReservedName = filePath[filePath.LastIndexOf(name) - 1];
              if (symbolBeforeReservedName == '\\')
              {
                return true;
              }
            }
          }
        }
      }
      return false;
    }

    // 3. Check filepath for spaces and empty entries, dots, backslashes in the end. 
    private bool ContainsIllegalSymbolsInTheEnd()
    {
      if (filePath[filePath.Length - 1] == ' ')
      {
        return true;
      }
      if (filePath[filePath.Length - 1] == '.')
      {
        return true;
      }
      if (filePath[filePath.Length - 1] == '\\')
      {
        return true;
      }
      return false;
    }

    // 4. Check filepath for \\\.
    private bool ContainsThreeOrMoreBackslashes()
    {
      if (filePath.Contains(@"\\\"))
      {
        return true;
      }
      return false;
    }

    // 5. Check filepath for \.\ or \..\
    private bool ContainsIllegalBackslashAndDotsCombinations()
    {
      if (filePath.Contains(@"\."))
      {
        string[] filePathCatalogs = filePath.Split('\\');
        bool contains = true;
        foreach (var catalog in filePathCatalogs)
        {
          foreach (char symbol in catalog)
          {
            if (symbol != '.')
            {
              contains = false;
              break;
            }
          }
        }
        if (contains && (filePath.StartsWith(@"\..\") || filePath.StartsWith(@"\..\..\")))
        {
          return false;
        }
      }

      return false;
    }

    // 6. Check filepath for 2 or more : symbols after diskname.
    private bool ContainsTwoOrMoreDoubleDotSymbols()
    {
      if (filePath[filePath.IndexOf(':') + 1] == ':')
      {
        return true;
      }
      return false;
    }

    // 7. Check filepath for valid disk name.
    private bool IsValidDiskName()
    {
      string filePathDiskName = filePath.Substring(0, filePath.IndexOf(':'));
      // 7.1 Check filepath for spaces after diskname.
      bool isValid = true;
      if (filePathDiskName[filePathDiskName.Length - 1] == ' ')
      {
        return false;
      }
      else
      {
        filePathDiskName = filePathDiskName.Replace(" ", string.Empty);
        isValid = false;
        // If diskname is not a single char, it is invalid.
        if (filePathDiskName.Length > 1)
        {
          return false;
        }

        int latinASmallCharAsciiCode = 65;
        int latinZSmallCharAsciiCode = 90;
        int latinABigCharAsciiCode = 97;
        int latinZBigCharAsciiCode = 122;

        int diskNameAsciiCode = (int)filePathDiskName.ToCharArray()[0];
        if ((diskNameAsciiCode >= latinASmallCharAsciiCode) &&
          (diskNameAsciiCode <= latinZSmallCharAsciiCode))
        {
          isValid = true;
        }

        if ((diskNameAsciiCode >= latinABigCharAsciiCode) &&
          (diskNameAsciiCode <= latinZBigCharAsciiCode))
        {
          isValid = true;
        }
      }

      return isValid;
    }

    // 8. Check filepath for illegal \/?\, /\?\, \\?/, ?\\\, \?\\, \\\? combinations.
    private bool ContainsIllegalTwobackslashQuestionmarkBackslashCombinations()
    {
      // Combination ?///.
      if (filePath.StartsWith("?"))
      {
        return true;
      }

      // Combination /\?\.
      if (filePath.StartsWith("/"))
      {
        return true;
      }

      // Other combinations.
      if (filePath.StartsWith("\\"))
      { 
        int illegalCombinationLength = 4;
        if (filePath.Substring(0, illegalCombinationLength) == @"\/?\")
        {
          return true;
        }
        if (filePath.Substring(0, illegalCombinationLength) == @"\\?/")
        {
          return true;
        }
        if (filePath.Substring(0, illegalCombinationLength) == @"\?\\")
        {
          return true;
        }
        if (filePath.Substring(0, illegalCombinationLength) == @"\\\?")
        {
          return true;
        }
      }

      return false;
    }
  }
}
