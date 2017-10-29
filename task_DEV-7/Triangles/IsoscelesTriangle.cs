using System;

namespace task_DEV_7
{
  class IsoscelesTriangle : SimpleTriangle
  {
    public IsoscelesTriangle(TriangleSides sides)
      : base()
    {
      if (sides.ContainsEqual() && sides.AreCoherence())
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
