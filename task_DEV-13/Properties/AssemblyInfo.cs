using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Globalization;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("task_DEV-13")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("task_DEV-13")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Параметр ComVisible со значением FALSE делает типы в сборке невидимыми 
// для COM-компонентов.  Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("8f04fc14-22cc-42cd-9b66-051e69fd835c")]

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
public class AssemblyInfo
{
  // Culture info.
  public static readonly CultureInfo culture = new CultureInfo("en-us");
  // Exceptions messages.
  public const string WRONG_CONDITIONS_EXCEPTION_MESSAGE = "Can't create an appropriate devs group for such needs.";
  // Messages.

  // Console args valid values.
  // Price.
  public const decimal MIN_PRICE = 0;
  // Efficiency.
  public const int MIN_EFFICIENCY = 0;
  // Criterion.
  public const string VALID_MAX_EFFICIENCY_CRITERION = "maxefficiency";
  public const string VALID_MIN_COST_CRITERION = "mincost";
  public const string VALID_MIN_NON_JUNIOR_DEVS_AMOUNT_CRITERION = "minnonjuniordevs";

  // Default company development staff setup.
  // Amount.
  // public const int JUNIOR_DEVS_AMOUNT = 30;
  // public const int MIDDLE_DEVS_AMOUNT = 15;
  // public const int SENIOR_DEVS_AMOUNT = 10;
  // public const int LEAD_DEVS_AMOUNT = 5;

  // Price.
  public const decimal JUNIOR_DEVS_PRICE = 500m;
  public const decimal MIDDLE_DEVS_PRICE = 1000m;
  public const decimal SENIOR_DEVS_PRICE = 2000m;
  public const decimal LEAD_DEVS_PRICE = 2500m;

  // Efficiency.
  public const int JUNIOR_DEVS_EFFICIENCY = 25;
  public const int MIDDLE_DEVS_EFFICIENCY = 50;
  public const int SENIOR_DEVS_EFFICIENCY = 75;
  public const int LEAD_DEVS_EFFICIENCY = 100;
}