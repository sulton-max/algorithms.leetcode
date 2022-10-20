namespace TwoSum_1
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length == 2)
                return new[] { 0, 1 };

            // Sort the array for binary search
            var numsCopy = new int[nums.Length];
            Array.Copy(nums, numsCopy, nums.Length);
            Array.Sort(numsCopy);

            (var valueA, var valueB) = (0, 0);
            (var indexA, var indexB) = (default(int?), default(int?));
            (var min, var max) = (numsCopy[0], numsCopy[nums.Length - 1]);

            // Iterate ordered array copy to find target values
            for (var index = 0; index < numsCopy.Length; index++)
            {
                // Check if target is out of boundaries
                if (numsCopy[index] > max || numsCopy[index] < min)
                    continue;

                var startIndex = 0;
                var endIndex = numsCopy.Length;
                var targetValue = default(int?);

                // Binary search to find the next target
                while (true)
                {
                    // Check if smallest set reached
                    if (endIndex - startIndex == 1)
                    {
                        targetValue = startIndex != index && numsCopy[index] + numsCopy[startIndex] == target
                            ? numsCopy[startIndex]
                            : endIndex < numsCopy.Length && endIndex != index && numsCopy[index] + numsCopy[endIndex] == target ? numsCopy[endIndex] : null;
                        break;
                    }

                    // Calculate and check median
                    var median = (endIndex - startIndex) / 2 + startIndex;
                    if (median != index && numsCopy[index] + numsCopy[median] == target)
                    {
                        targetValue = numsCopy[median];
                        break;
                    }

                    // Recalculate boundaries
                    (startIndex, endIndex) = numsCopy[median] < target - numsCopy[index] ? (median, endIndex) : (startIndex, median);
                }

                if (targetValue.HasValue)
                {
                    (valueA, valueB) = (numsCopy[index], targetValue.Value);
                    break;
                }
            }

            // Find target value original indexes from array
            for (var index = 0; index < nums.Length / 2 + 1; index++)
            {
                if (indexA.HasValue && indexB.HasValue)
                    break;

                indexA = indexA.HasValue
                    ? indexA
                    : valueA == nums[index]
                        ? index
                        : valueA == nums[nums.Length - 1 - index] ? nums.Length - 1 - index : indexA;
                indexB = indexB.HasValue
                    ? indexB
                    : valueB == nums[index] && (!indexA.HasValue || index != indexA.Value)
                        ? index
                        : valueB == nums[nums.Length - 1 - index] && (!indexA.HasValue || nums.Length - 1 - index != indexA.Value) ? nums.Length - 1 - index : indexB;
            }

            return (indexA.HasValue && indexB.HasValue)
                ? new[] { indexA.Value, indexB.Value }
                : new int[0];
        }
    }
}
