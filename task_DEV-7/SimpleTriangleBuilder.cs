using System;

namespace task_DEV_7
{
    class SimpleTriangleBuilder : TriangleBuilder
    {
        public SimpleTriangleBuilder(SimpleTriangleBuilder invokedBuilder)
        {
            this.invokedBuilder = invokedBuilder;
        }
        public override SimpleTriangle Build(Sides sides)
        {
            SimpleTriangle triangle = null;
            string message;
            try
            {
                triangle = new SimpleTriangle(sides);
                message = AssemblyInfo.triangleBuildSuccessMessage;
            }
            catch (WrongSidesException)
            {
                triangle = invokedBuilder != null
                    ? invokedBuilder.Build(sides)
                    : null;
                message = AssemblyInfo.notExistedTriangle;
            }
            Console.WriteLine(message);

            return triangle;
        }
    }
}
