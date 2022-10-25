namespace CountNegativeNumbersInASortedMatrix_1351
{
    public class Solution
    {
        public int CountNegatives(int[][] grid)
        {
            // Binary search to find A and B points
            // A - point where rows with full negative elements start
            (var sizeA, var sizeB) = (grid.Length, grid[0].Length);
            (var startIndexA, var endIndexA, var pointA) = (0, sizeA, default(int?));
            if (sizeA > 1)
                while (true)
                {
                    // Check if smallest subset reached
                    if (endIndexA - startIndexA == 1)
                    {
                        pointA = grid[startIndexA][0] < 0 && (startIndexA < 1 || grid[startIndexA][0] >= 0)
                            ? startIndexA
                            : endIndexA < sizeA && grid[endIndexA][0] < 0 && grid[startIndexA][0] >= 0 ? endIndexA : null;
                        break;
                    }

                    // Calculate median and check
                    var median = (endIndexA - startIndexA) / 2 + startIndexA;
                    if (grid[median][0] < 0 && (median < 1 || grid[median - 1][0] >= 0))
                        pointA = median;

                    // Recalculate boundaries
                    (startIndexA, endIndexA) = grid[median][0] >= 0 ? (median, endIndexA) : (startIndexA, median);
                }

            pointA = !pointA.HasValue ? sizeA : pointA; // Adjust point A

            // Iterate to calculate all negative numbers
            var negativeNumsCount = (sizeA - pointA.Value) * sizeB;
            for (var index = 0; index < pointA; index++)
            {
                (var startIndexB, var endIndexB, var pointB) = (0, sizeB, default(int?));

                // Binary search to find point B
                // B - point where the negative numbers start inside inner array
                while (true)
                {
                    // Check if smallest subset reached
                    if (endIndexB - startIndexB == 1)
                    {
                        pointB = grid[index][startIndexB] < 0 && (startIndexB < 1 || grid[index][startIndexB - 1] >= 0)
                            ? startIndexB
                            : endIndexB < sizeB && grid[index][endIndexB] < 0 && grid[index][startIndexB] >= 0 ? endIndexB : null;
                        break;
                    }

                    // Calculate median and check
                    var median = (endIndexB - startIndexB) / 2 + startIndexB;
                    if (grid[index][median] < 0 && (median < 1 || grid[index][median - 1] >= 0))
                    {
                        pointB = median;
                        break;
                    }

                    // Recalculate boundaries
                    (startIndexB, endIndexB) = grid[index][median] >= 0 ? (median, endIndexB) : (startIndexB, median);
                }

                negativeNumsCount = pointB.HasValue ? negativeNumsCount + sizeB - pointB.Value : negativeNumsCount;
            }

            return negativeNumsCount;
        }
    }
}
