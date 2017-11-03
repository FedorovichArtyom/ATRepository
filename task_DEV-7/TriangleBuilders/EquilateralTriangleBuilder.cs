using System;

namespace task_DEV_7
{
  public class EquilateralTriangleBuilder : TriangleBuilder
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
        if (invokedBuilder != null)
        {
          triangle = invokedBuilder.Build(sides);
        }
        else
        {
          throw new WrongSidesException();
        }
      }

      return triangle;
    }

  }
}
