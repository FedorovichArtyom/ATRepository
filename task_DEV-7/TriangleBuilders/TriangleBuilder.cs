using System;

namespace task_DEV_7
{
  abstract class TriangleBuilder
  {
    protected TriangleBuilder invokedBuilder;
    public abstract SimpleTriangle Build(TriangleSides sides);
  }
}
