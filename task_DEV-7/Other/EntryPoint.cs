using System;

namespace task_DEV_7
{
  class EntryPoint
  {
    static void Main(string[] args)
    {
      SimpleTriangleBuilder triangleBuilder = new SimpleTriangleBuilder();
      IsoscelesTriangleBuilder isoscelesTriangleBuilder = new IsoscelesTriangleBuilder(triangleBuilder);
      EquilateralTriangleBuilder equilateralTriangleBuilder = new EquilateralTriangleBuilder(isoscelesTriangleBuilder);

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

      Console.WriteLine(triangle.Sides.First);
      Console.WriteLine(triangle.Sides.Second);
      Console.WriteLine(triangle.Sides.Third);
      Console.WriteLine(triangle.GetType().Name);
    }
  }
}
