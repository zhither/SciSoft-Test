using System;
using CSharpTest.Shapes;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Parking Slot Calculator
            Console.WriteLine("Task 1: Parking Slot Calculator");
            int totalSlots = ParkingSlotCalculator.CalculateMinimumOccupiedSlots(2, 3, 1, 4);
            Console.WriteLine($"Total slots occupied: {totalSlots}\n");

            // Task 2: Drawing Shapes
            Console.WriteLine("Task 2: Drawing Shapes");
            Shape triangle = new Triangle(3, 4, 5);
            Shape rectangle = new Rectangle(5, 10);
            Shape circle = new Circle(7);

            ICanvas bitmapCanvas = new BitmapCanvas();
            triangle.Draw(bitmapCanvas);
            rectangle.Draw(bitmapCanvas);
            circle.Draw(bitmapCanvas);

            ICanvas exportCanvas = new ExportCanvas("shapes.txt");
            triangle.Draw(exportCanvas);
            rectangle.Draw(exportCanvas);
            circle.Draw(exportCanvas);

            Console.WriteLine("\nShapes drawn on canvases.\n");

            // Task 3: Code Refactoring
            Console.WriteLine("Task 3: Code Refactoring");
            double totalSum, average;
            CodeRefactoring.CalculateSumAndAverage(10.0, 2.0, out totalSum, out average);
            Console.WriteLine($"Total Sum: {totalSum}, Average: {average}");
        }
    }
}
