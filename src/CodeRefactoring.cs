using System;

namespace CSharpTest
{
    public static class CodeRefactoring
    {
        /// <summary>
        /// Calculates the sum and average of a series of values based on inputs 'a' and 'b'.
        /// </summary>
        /// <param name="a">First double parameter.</param>
        /// <param name="b">Second double parameter. Must not be zero.</param>
        /// <param name="sum">Output parameter to store the sum of the calculated values.</param>
        /// <param name="average">Output parameter to store the average of the calculated values.</param>
        public static void CalculateSumAndAverage(double a, double b, out double sum, out double average)
        {
            // Check for division by zero to prevent runtime errors.
            if (b == 0)
                throw new DivideByZeroException("Parameter 'b' cannot be zero.");

            // Calculate the quotient to determine the number of iterations.
            int quotient = (int)Math.Floor(a / b) + 1;

            // Initialize an array to store calculated values based on 'a' and 'b'.
            double[] results = new double[quotient];

            // Populate the results array with calculated values.
            for (int i = 0; i < quotient; i++)
            {
                results[i] = i * a * b;
            }

            // Initialize the sum to zero.
            sum = 0;

            // Calculate the sum of all values in the results array.
            foreach (var value in results)
            {
                sum += value;
            }

            // Calculate the average by dividing the sum by the number of elements.
            average = sum / quotient;
        }
    }
}
