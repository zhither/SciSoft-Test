using System;
using System.IO;

namespace CSharpTest.Shapes
{
    public class BitmapCanvas : ICanvas
    {
        private readonly string _outputFilePath;

        public BitmapCanvas(string outputDirectory = "output", string outputFileName = "bitmap_shapes.txt")
        {
            // Determine the output directory
            string baseDirectory = Directory.GetCurrentDirectory();
            _outputFilePath = Path.Combine(baseDirectory, outputDirectory, outputFileName);

            // Ensure the output directory exists
            string fullOutputDirectory = Path.GetDirectoryName(_outputFilePath);
            if (!Directory.Exists(fullOutputDirectory))
            {
                Directory.CreateDirectory(fullOutputDirectory);
            }
        }

        public void Draw(Triangle triangle)
        {
            Console.WriteLine("Drawing Triangle on BitmapCanvas.");
            // Implement triangle drawing logic here
            ExportShapeDetails("Triangle", new string[]
            {
                $"Sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}",
                $"Area: {triangle.CalculateArea()}"
            });
        }

        public void Draw(Rectangle rectangle)
        {
            Console.WriteLine("Drawing Rectangle on BitmapCanvas.");
            // Implement rectangle drawing logic here
            ExportShapeDetails("Rectangle", new string[]
            {
                $"Width: {rectangle.Width}, Height: {rectangle.Height}",
                $"Area: {rectangle.CalculateArea()}"
            });
        }

        public void Draw(Circle circle)
        {
            Console.WriteLine("Drawing Circle on BitmapCanvas.");
            // Implement circle drawing logic here
            ExportShapeDetails("Circle", new string[]
            {
                $"Radius: {circle.Radius}",
                $"Area: {circle.CalculateArea()}"
            });
        }

        private void ExportShapeDetails(string shapeName, string[] details)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_outputFilePath, append: true))
                {
                    writer.WriteLine($"{shapeName}:");
                    foreach (var detail in details)
                    {
                        writer.WriteLine($"  {detail}");
                    }
                    writer.WriteLine(); // Blank line to separate shapes
                }
                Console.WriteLine($"Exported {shapeName} details to {_outputFilePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to {_outputFilePath}: {ex.Message}");
            }
        }
    }
}
