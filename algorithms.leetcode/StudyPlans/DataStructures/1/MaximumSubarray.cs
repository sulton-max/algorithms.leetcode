namespace MaximumSubarray_53
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length < 2)
                return nums == null ? 0 : nums[0];

            var maxSubArraySum = default(int?)!;
            for (int indexA = 0; indexA < nums.Length; indexA++)
            {
                int currentArraySum = nums[indexA];
                for (int indexB = indexA + 1; indexB < nums.Length; indexB++)
                {
                    if (currentArraySum + nums[indexB] < (currentArraySum / 2))
                        break;
                    else currentArraySum += nums[indexB];
                }

                maxSubArraySum = !maxSubArraySum.HasValue
                    ? currentArraySum
                    : maxSubArraySum.Value < currentArraySum
                        ? currentArraySum
                        : maxSubArraySum.Value;
            }

            return maxSubArraySum.Value;
        }
    }
}
