namespace IntersectionOfTwoArraysII_350
{
    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 1 || nums2.Length == 1)
            {
                // Check if one of the arrays has only one element and whether it is intersected element or not
                var number = nums1.Length == 1 && Contains(nums2, nums1[0])
                    ? nums1[0]
                    : Contains(nums1, nums2[0]) ? nums2[0] : default(int?);
                return number.HasValue ? new[] { number.Value } : new int[0];
            }

            // Sort arrays
            Array.Sort(nums1);
            Array.Sort(nums2);

            var indexA = 0;
            var indexB = 0;
            var indexC = 0;
            var mergeNums = new int[nums1.Length + nums2.Length];

            while (true)
            {
                // Check if array elements intersects
                if (nums1[indexA] == nums2[indexB])
                {
                    mergeNums[indexC++] = nums1[indexA];
                    (indexA, indexB) = (indexA + 1, indexB + 1);
                }
                else if (nums1[indexA] < nums2[indexB])
                    indexA++;
                else
                    indexB++;

                if (indexA == nums1.Length || indexB == nums2.Length)
                    break;
            }

            Array.Resize<int>(ref mergeNums, indexC);
            return mergeNums;
        }

        public bool Contains(int[] nums, int value)
        {
            for (var index = 0; index < nums.Length; index++)
                if (nums[index] == value)
                    return true;

            return false;
        }
    }
}
