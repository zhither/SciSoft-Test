using System;

namespace CSharpTest
{
    public static class ParkingSlotCalculator
    {
        public static int CalculateMinimumOccupiedSlots(int bigSlots, int smallSlots, int buses, int cars)
        {
            // Ensure all input parameters are non-negative
            bigSlots = Math.Max(0, bigSlots);
            smallSlots = Math.Max(0, smallSlots);
            buses = Math.Max(0, buses);
            cars = Math.Max(0, cars);

            // Step 1: Allocate buses to big slots
            int busesAllocated = Math.Min(buses, bigSlots);
            int remainingBigSlots = bigSlots - busesAllocated;

            // Step 2: Allocate cars to big slots (3 cars per big slot)
            int maxCarsInBigSlots = remainingBigSlots * 3;
            int carsAllocatedToBigSlots = Math.Min(cars, maxCarsInBigSlots);
            int bigSlotsUsedForCars = (int)Math.Ceiling(carsAllocatedToBigSlots / 3.0);

            // Step 3: Allocate remaining cars to small slots (1 car per small slot)
            int remainingCars = cars - carsAllocatedToBigSlots;
            int carsAllocatedToSmallSlots = Math.Min(remainingCars, smallSlots);
            int smallSlotsUsed = carsAllocatedToSmallSlots;

            // Total slots occupied
            int totalSlotsUsed = busesAllocated + bigSlotsUsedForCars + smallSlotsUsed;

            return totalSlotsUsed;
        }
    }
}
