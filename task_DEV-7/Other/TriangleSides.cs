using System;

namespace task_DEV_7
{
  public struct TriangleSides
  {
    public double First;
    public double Second;
    public double Third;

    public bool AreCoherence()
    {
      return ((First + Second > Third) &&
        (Second + Third > First) &&
        (First + Third > Second));
    }

    public bool ContainEqual()
    {
      return Math.Abs(First - Second) < double.Epsilon ||
        Math.Abs(Second - Third) < double.Epsilon ||
        Math.Abs(Third - First) < double.Epsilon;
    }

    public bool AreEqual()
    {
      return Math.Abs(First - Second) < double.Epsilon &&
        Math.Abs(Second - Third) < double.Epsilon;
    }
  }
}
