namespace SearchInsertPosition_35
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            // Validate the set
            if (nums == null || nums.Length < 1)
                return -1;

            // Check the boundaries
            if (nums[0] > target || nums[nums.Length - 1] < target)
                return (nums[0] > target) ? 0 : nums.Length;

            if (nums.Length == 1)
                return nums[0] == target ? 0 : nums[0] < target ? 1 : 0;

            var startIndex = 0;
            var endIndex = nums.Length - 1;
            while (true)
            {
                if (endIndex - startIndex == 1)
                    return nums[startIndex] == target ? startIndex : startIndex + 1;

                // Calculate the root for the current subset
                // Calcuate the upper and lower boundaries of current subset 
                var median = (endIndex - startIndex) / 2 + startIndex;
                if (nums[median] == target)
                    return median;

                startIndex = nums[median] < target ? median : startIndex;
                endIndex = nums[median] > target ? median : endIndex;
            }
        }
    }
}
