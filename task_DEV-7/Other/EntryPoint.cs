using System;

namespace task_DEV_7
{
  class EntryPoint
  {
    static void Main(string[] args)
    {
      SimpleTriangleBuilder triangleBuilder = new SimpleTriangleBuilder();
      IsoscelesTriangleBuilder isoscelesTriangleBuilder = new IsoscelesTriangleBuilder(triangleBuilder);
      //EquilateralTriangleBuilder equilateralTriangleBuilder = new EquilateralTriangleBuilder(isoscelesTriangleBuilder);
      EquilateralTriangleBuilder equilateralTriangleBuilder = new EquilateralTriangleBuilder(null);

      SimpleTriangle triangle = null;
      bool builded = false;
      while (!builded)
      {
        try
        {
          triangle = equilateralTriangleBuilder.Build((new InputHandler()).GetSidesFromConsole());
          builded = true;
        }
        catch (Exception ex)
        {
          Console.WriteLine(AssemblyInfo.notExistedTriangle);
        }
      }

      Console.WriteLine(AssemblyInfo.triangleBuildSuccessMessage);
      Console.WriteLine(triangle.GetType().Name);
    }
  }
}
