using System;

namespace task_DEV_7
{
    class IsoscelesTriangle : SimpleTriangle
    {
        public IsoscelesTriangle(Sides sides) : base()
        {
            if (CanBuildIsoscelesTriangle(sides))
            {
                this.sides = sides;
            }
            else
            {
                throw new WrongSidesException(AssemblyInfo.notExistedIsoscelesTriangle);
            }
        }

        private bool CanBuildIsoscelesTriangle(Sides sides)
        {
            return CanBuildTriangle(sides) && (sides.First == sides.Second ||
                sides.Second == sides.Third || sides.Third == sides.First);
        }
    }
}
