using System;

namespace task_DEV_7
{
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        public EquilateralTriangleBuilder(TriangleBuilder invokedBuilder)
        {
            this.invokedBuilder = invokedBuilder;
        }

        public override SimpleTriangle Build(Sides sides)
        {
            SimpleTriangle triangle;
            try
            {
                triangle = new EquilateralTriangle(sides);
            }
            catch (WrongSidesException)
            {
                triangle = invokedBuilder.Build(sides);
            }
            
            return triangle;
        }
        
    }
}
