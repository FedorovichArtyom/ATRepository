using System;

namespace task_DEV_7
{

  class IsoscelesTriangleBuilder : TriangleBuilder
  {
    public IsoscelesTriangleBuilder(TriangleBuilder invokedBuilder)
    {
      this.invokedBuilder = invokedBuilder;
    }
    public override SimpleTriangle Build(TriangleSides sides)
    {
      SimpleTriangle triangle;
      try
      {
        triangle = new IsoscelesTriangle(sides);
      }
      catch (WrongSidesException)
      {
        triangle = invokedBuilder.Build(sides);
      }
      return triangle;
    }
  }
}
