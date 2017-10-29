using System;

namespace task_DEV_7
{
  public class SimpleTriangle
  {
    protected TriangleSides sides;
    public TriangleSides Sides
    {
      set { sides = value; }
      get { return sides; }
    }

    protected SimpleTriangle() 
    {

    }
    public SimpleTriangle(TriangleSides sides)
    {
      if (sides.AreCoherence())
      {
        this.sides = sides;
      }
      else
      {
        throw new WrongSidesException(AssemblyInfo.notExistedTriangle);
      }
    }
  }
}
