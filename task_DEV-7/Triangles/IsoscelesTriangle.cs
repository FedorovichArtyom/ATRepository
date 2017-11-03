using System;

namespace task_DEV_7
{
  public class IsoscelesTriangle : SimpleTriangle
  {
    public IsoscelesTriangle(TriangleSides sides)
      : base(sides)
    {
      if (sides.ContainEqual())
      {
        this.sides = sides;
      }
      else
      {
        throw new WrongSidesException(AssemblyInfo.notExistedIsoscelesTriangle);
      }
    }
  }
}
