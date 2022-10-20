namespace BinarySearch_704
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length < 2)
                return nums[0] == target ? 0 : -1;

            var startIndex = 0;
            var endIndex = nums.Length;

            while(true)
            {
                if (endIndex - startIndex == 1)
                    return nums[startIndex] == target ? startIndex : endIndex < nums.Length && nums[endIndex] == target ? endIndex : -1;

                var median = (endIndex - startIndex) / 2 + startIndex;
                if (nums[median] == target)
                    return median;

                (startIndex, endIndex) = nums[median] < target ? (median, endIndex) : (startIndex, median);
            }
        }
    }
}
