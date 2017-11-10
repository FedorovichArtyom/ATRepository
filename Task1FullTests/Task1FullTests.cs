using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Full;

namespace Task1FullTests
{
  [TestClass]
  public class Task1FullTests
  {
    // Positive tests.
    [TestMethod]
    public void TestIsValidForValidFilePath()
    {
      // Arrange.
      string filePath = @"D:\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForTwoBackslashesQuestionmarkBackslashCombination()
    {
      // Arrange.
      string filePath = @"\\?\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForBackslashTwoDotesBackslashInTheBeginnigCombination()
    {
      // Arrange.
      string filePath = @"\..\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }
    [TestMethod]
    public void TestIsValidForBackslashTwiceTwoDotesBackslashInTheBeginnigCombination()
    {
      // Arrange.
      string filePath = @"\..\..\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForBackslashAfterDiskNameNotExisting()
    {
      // Arrange.
      string filePath = @"D:Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForValidDiskName()
    {
      // Arrange.
      string filePath = @"D:\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForValidRelativePathWithDot()
    {
      // Arrange.
      string filePath = @".\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForValidRelativePathWithDots()
    {
      // Arrange.
      string filePath = @"..\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }

    [TestMethod]
    public void TestIsValidForValidRelativePath()
    {
      // Arrange.
      string filePath = @"\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(true, isValid);
    }


    // Negative tests.
    [TestMethod]
    public void TestIsValidForUnsupportedSymbols()
    {
      // Arrange.
      string filePathWithOrdinaryUnsupportedSymbols =
        @"D:\Study\EPAM\control|work<>\TAT0003.test01\file.txt";

      string filePathWithNotOrdinaryUnsupportedSymbols =
        "D:\\Study\\EPAM\\cont\b\trolwork\\TAT0003.test01\\file.txt";
      var validatorOrdinarySymbols = new FilePathValidator(filePathWithOrdinaryUnsupportedSymbols);
      var validatorNotOrdinarySymbols = new FilePathValidator(filePathWithNotOrdinaryUnsupportedSymbols);

      // Act.
      bool isValidOrdinary = validatorOrdinarySymbols.IsValid();
      bool isValidNotOrdinary = validatorNotOrdinarySymbols.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidOrdinary);
      Assert.AreEqual(false, isValidNotOrdinary);
    }

    [TestMethod]
    public void TestIsValidForReservedNamesInFilePathName()
    {
      // Arrange.
      string filePathWithReservedName = @"D:\Study\EPAM\controlwork\TAT0003.test01\COM.txt";
      string filePathWithoutReservedName = @"D:\Study\EPAM\controlwork\TAT0003.test01\COMmandante.txt";
      string filePathCombinedNotValid = @"D:\Study\EPAM\controlwork\COM.txt\TAT0003.test01\COM.txt";
      string filePathCombinedValid = @"D:\Study\EPAM\controlwork\COM.txt\TAT0003.test01\COMmandante.txt";
      var validatorForReservedNames = new FilePathValidator(filePathWithReservedName);
      var validatorForNotReservedNames = new FilePathValidator(filePathWithoutReservedName);
      var validatorForCombinedNotValidFilePath = new FilePathValidator(filePathCombinedNotValid);
      var validatorForCombinedValidFilePath = new FilePathValidator(filePathCombinedValid);

      // Act.
      bool isValidWithReservedNames = validatorForReservedNames.IsValid();
      bool isValidWithoutReservedNames = validatorForNotReservedNames.IsValid();
      bool isValidForCombinedNotValidFilePath = validatorForCombinedNotValidFilePath.IsValid();
      bool isValidForCombinedValidFilePath = validatorForCombinedValidFilePath.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidWithReservedNames);
      Assert.AreEqual(true, isValidWithoutReservedNames);
      Assert.AreEqual(false, isValidForCombinedNotValidFilePath);
      Assert.AreEqual(true, isValidForCombinedValidFilePath);
    }

    [TestMethod]
    public void TestIsValidForSpacesInTheEndOfFilePath()
    {
      // Arrange.
      string filePath = @"D:\Study\EPAM\controlwork\TAT0003.test01\file.txt ";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForTabsInTheEndOfFilePath()
    {
      // Arrange.
      string filePath = "D:\\Study\\EPAM\\controlwork\\TAT0003.test01\\file.txt\t";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForDotsInTheEndOfFilePath()
    {
      // Arrange.
      string filePath = "D:\\Study\\EPAM\\controlwork\\TAT0003.test01\\file.txt.";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForBackslashesInTheEndOfFilePath()
    {
      // Arrange.
      string filePath = "D:\\Study\\EPAM\\controlwork\\TAT0003.test01\\file.txt\\";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForThreeOrMoreBackslashesInARow()
    {
      // Arrange.
      string filePath = @"D:\Study\EPAM\controlwork\\\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForBackslashDotBackslashCombinations()
    {
      // Arrange.
      string filePath = @"D:\Study\EPAM\controlwork\.\TAT0003.test01\file.txt";
      FilePathValidator validator = new FilePathValidator(filePath);

      // Act.
      bool isValid = validator.IsValid();

      // Assert.
      Assert.AreEqual(false, isValid);
    }

    [TestMethod]
    public void TestIsValidForBackslashDotsBackslashCombinations()
    {
      // Arrange.
      string filePathWithTwoDots = @"D:\Study\EPAM\controlwork\..\TAT0003.test01\file.txt";
      string filePathWithManyDots = @"D:\Study\EPAM\controlwork\......\TAT0003.test01\file.txt";
      FilePathValidator validatorForTwoDots = new FilePathValidator(filePathWithTwoDots);
      FilePathValidator validatorForManyDots = new FilePathValidator(filePathWithManyDots);

      // Act.
      bool isValidForTwoDots = validatorForTwoDots.IsValid();
      bool isValidForManyDots = validatorForManyDots.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidForTwoDots);
      Assert.AreEqual(false, isValidForManyDots);
    }

    [TestMethod]
    public void TestIsValidForTwoOrMoreDoubleDotsAfterDiskName()
    {
      // Arrange.
      string filePathWithDoubleDot = @"D::\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathWithManyDoubleDots = @"D::::\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      FilePathValidator validatorForDoubleDots = new FilePathValidator(filePathWithDoubleDot);
      FilePathValidator validatorForManyDoubleDots = new FilePathValidator(filePathWithManyDoubleDots);

      // Act.
      bool isValidForDoubleDots = validatorForDoubleDots.IsValid();
      bool isValidForManyDoubleDots = validatorForManyDoubleDots.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidForDoubleDots);
      Assert.AreEqual(false, isValidForManyDoubleDots);
    }

    [TestMethod]
    public void TestIsValidForInvalidDiskName()
    {
      // Arrange.
      string filePathWithNotASingleSymbolDiskName =
        @"Dq:\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathWithInvalidDiskNameSymbol =
        @"#:\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      var validatorForNotASingleSymbolDiskName = new FilePathValidator(filePathWithNotASingleSymbolDiskName);
      var validatorForInvalidDiskNameSymbol = new FilePathValidator(filePathWithInvalidDiskNameSymbol);

      // Act.
      bool isValidForNotASingleSymbolDiskName = validatorForNotASingleSymbolDiskName.IsValid();
      bool isValidForNotInvalidDiskNameSymbol = validatorForInvalidDiskNameSymbol.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidForNotASingleSymbolDiskName);
      Assert.AreEqual(false, isValidForNotInvalidDiskNameSymbol);
    }

    [TestMethod]
    public void TestIsValidForTwoBackslashesQuestionmarkBackslashNotValidCombination()
    {
      // Arrange.
      string filePathFirstCase = @"\/?\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathSecondCase = @"/\?\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathThirdCase = @"\\?/Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathForthCase = @"\?\\Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathFifthCase = @"\\\?Study\EPAM\controlwork\TAT0003.test01\file.txt";
      string filePathSixthCase = @"?\\\Study\EPAM\controlwork\TAT0003.test01\file.txt";

      var validatorFirstCase = new FilePathValidator(filePathFirstCase);
      var validatorSecondCase = new FilePathValidator(filePathSecondCase);
      var validatorThirdCase = new FilePathValidator(filePathThirdCase);
      var validatorForthCase = new FilePathValidator(filePathForthCase);
      var validatorFifthCase = new FilePathValidator(filePathFifthCase);
      var validatorSixthCase = new FilePathValidator(filePathSixthCase);

      // Act.
      bool isValidFirstCase = validatorFirstCase.IsValid();
      bool isValidSecondCase = validatorSecondCase.IsValid();
      bool isValidThirdCase = validatorThirdCase.IsValid();
      bool isValidForthCase = validatorForthCase.IsValid();
      bool isValidFifthCase = validatorFifthCase.IsValid();
      bool isValidSixthCase = validatorSixthCase.IsValid();

      // Assert.
      Assert.AreEqual(false, isValidFirstCase);
      Assert.AreEqual(false, isValidSecondCase);
      Assert.AreEqual(false, isValidThirdCase);
      Assert.AreEqual(false, isValidForthCase);
      Assert.AreEqual(false, isValidFifthCase);
      Assert.AreEqual(false, isValidSixthCase);
    }
  }
}
