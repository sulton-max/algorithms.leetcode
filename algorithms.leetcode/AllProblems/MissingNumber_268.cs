namespace MissingNumber_268
{
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0] == 1 ? 0 : 1;

            // Check whether the array contains zero and calculate sum btw
            var containsZero = false;
            var sum = 0;
            for (var index = 0; index < nums.Length; index++)
            {
                containsZero = nums[index] == 0 ? true : containsZero;
                sum += nums[index];
            }

            // If array contains zero, then the missing number calculated simply
            return containsZero ? ((nums.Length + 1) * nums.Length / 2) - sum : 0;
        }
    }
}
