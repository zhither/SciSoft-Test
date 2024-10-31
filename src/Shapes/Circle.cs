using System;

namespace CSharpTest.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be greater than zero.");
            }

            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Draw(this);
        }
    }
}
