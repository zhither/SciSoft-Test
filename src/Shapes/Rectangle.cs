using System;

namespace CSharpTest.Shapes
{
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be greater than zero.");
            }

            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Draw(this);
        }
    }
}
