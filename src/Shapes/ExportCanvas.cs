using System;
using System.IO;

namespace CSharpTest.Shapes
{
    public class ExportCanvas : ICanvas
    {
        private readonly string _filePath;

        public ExportCanvas(string filePath)
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            // Clear the file before writing
            File.WriteAllText(_filePath, $"Exported Shapes Details - {DateTime.Now}\n\n");
        }

        public void Draw(Triangle triangle)
        {
            Console.WriteLine("Exporting Triangle points to file.");
            ExportShapePoints("Triangle", new double[] { triangle.SideA, triangle.SideB, triangle.SideC });
        }

        public void Draw(Rectangle rectangle)
        {
            Console.WriteLine("Exporting Rectangle points to file.");
            ExportShapePoints("Rectangle", new double[] { rectangle.Width, rectangle.Height });
        }

        public void Draw(Circle circle)
        {
            Console.WriteLine("Exporting Circle points to file.");
            ExportShapePoints("Circle", new double[] { circle.Radius });
        }

        private void ExportShapePoints(string shapeName, double[] parameters)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
                writer.WriteLine($"{shapeName} with parameters: {string.Join(", ", parameters)}");
            }
            Console.WriteLine($"Exported {shapeName} parameters to {_filePath}.");
        }
    }
}
