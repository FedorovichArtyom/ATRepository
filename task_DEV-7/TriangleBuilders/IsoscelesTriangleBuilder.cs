using System;

namespace task_DEV_7
{
  public class IsoscelesTriangleBuilder : TriangleBuilder
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
