using System;

namespace task_DEV_7
{
    public struct Sides
    {
        public double First;
        public double Second;
        public double Third;
    }
    public class SimpleTriangle
    {
        protected Sides sides;
        public Sides Sides
        {
            set { sides = value; }
            get { return sides; }
        }

        protected SimpleTriangle() { }
        public SimpleTriangle(Sides sides)
        {
            if (CanBuildTriangle(sides))
            {
                this.sides = sides;
            }
            else
            {
                throw new WrongSidesException(AssemblyInfo.notExistedTriangle);
            }
        }

        protected bool CanBuildTriangle(Sides sides)
        {
            return CoherenceSides(sides);
        }
        private bool CoherenceSides(Sides sides)
        {
            return ((sides.First + sides.Second > sides.Third) &&
                (sides.Second + sides.Third > sides.First) &&
                (sides.First + sides.Third > sides.Second));
        }
    }
}
