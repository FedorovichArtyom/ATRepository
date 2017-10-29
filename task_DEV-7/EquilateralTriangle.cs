using System;

namespace task_DEV_7
{
    class EquilateralTriangle : IsoscelesTriangle
    {
        public EquilateralTriangle(Sides sides) : base(sides)
        {
            if (CanBuildEquilateralTriangle(sides))
            {
                this.sides = sides;
            }
            else
            {
                throw new WrongSidesException(AssemblyInfo.notExistedEquilateralTriangle);
            }
        }

        private bool CanBuildEquilateralTriangle(Sides sides)
        {
            return CanBuildTriangle(sides) && (sides.First == sides.Second) &&
                (sides.Second == sides.Third);
        }
    }
}
