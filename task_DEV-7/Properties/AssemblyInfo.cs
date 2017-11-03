using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("task_DEV-7")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("task_DEV-7")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Параметр ComVisible со значением FALSE делает типы в сборке невидимыми 
// для COM-компонентов.  Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("6a515702-d952-4e18-bd21-714a1eb03606")]

// Сведения о версии сборки состоят из следующих четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии 
//      Номер построения
//      Редакция
//
// Можно задать все значения или принять номер построения и номер редакции по умолчанию, 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

internal static class AssemblyInfo
{
  // Culture info setup.
  internal const string inputDataCultureFormat = "en";
  // Math constants.
  internal const int triangleSidesNumber = 3;
  // System messages printed in console.
  internal const string enterTriangleSides =
    "Enter sides of the triangle. Separate values with spaces.";
  internal const string unparsedInputValues =
    "\nCan't parse sides values. Try again.";
  internal const string invalidNumberOfInputValues =
    "\nInvalid number of inputing values.";
  internal const string notExistedTriangle =
    "\nCan't create a triangle with such sides.";
  internal const string notExistedIsoscelesTriangle =
    "\nCan't create an isosceles triangle with such sides.";
  internal const string notExistedEquilateralTriangle =
    "\nCan't create an equilateral triangle with such sides.";
  internal const string overflowSidesValues = 
    "Inputted values are out of double range! Try again.";
  internal const string triangleBuildSuccessMessage =
    "\nTriangle exists! Type:";
}
