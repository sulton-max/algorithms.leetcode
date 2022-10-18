using System.CodeDom;
using System.Dynamic;

namespace ContainsDuplicate_217
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return false;

            var containsDuplicate = false;
            for (int indexA = 0; indexA < nums.Length; indexA++)
                for (int indexB = 0; indexB < nums.Length; indexB++)
                {
                    if (indexA == indexB)
                        continue;

                    if (nums[indexA] == nums[indexB])
                    {
                        containsDuplicate = true;
                        break;
                    }
                }

            return containsDuplicate;
        }
    }
}