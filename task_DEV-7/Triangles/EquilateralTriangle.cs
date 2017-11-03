using System;

namespace task_DEV_7
{
  public class EquilateralTriangle : IsoscelesTriangle
  {
    public EquilateralTriangle(TriangleSides sides)
      : base(sides)
    {
      if (sides.AreEqual())
      {
        this.sides = sides;
      }
      else
      {
        throw new WrongSidesException(AssemblyInfo.notExistedEquilateralTriangle);
      }
    }
  }
}
