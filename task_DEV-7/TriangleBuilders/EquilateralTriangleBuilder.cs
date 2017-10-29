using System;

namespace task_DEV_7
{
  class EquilateralTriangleBuilder : TriangleBuilder
  {
    public EquilateralTriangleBuilder(TriangleBuilder invokedBuilder)
    {
      this.invokedBuilder = invokedBuilder;
    }

    public override SimpleTriangle Build(TriangleSides sides)
    {
      SimpleTriangle triangle;
      try
      {
        triangle = new EquilateralTriangle(sides);
      }
      catch (WrongSidesException ex)
      {
        triangle = invokedBuilder.Build(sides);
      }

      return triangle;
    }

  }
}
