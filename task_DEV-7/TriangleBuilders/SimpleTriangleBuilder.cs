using System;

namespace task_DEV_7
{
  class SimpleTriangleBuilder : TriangleBuilder
  {
    public override SimpleTriangle Build(TriangleSides sides)
    {
      SimpleTriangle triangle = null;
      try
      {
        triangle = new SimpleTriangle(sides);
      }
      catch (WrongSidesException ex)
      {
        throw new WrongSidesException(AssemblyInfo.notExistedTriangle);
      }

      return triangle;
    }
  }
}
