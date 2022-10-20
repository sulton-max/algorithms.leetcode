namespace MergeSortedArray_88
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;

            // Define iteration points
            var indexA = m - 1;
            var indexB = n - 1;
            var indexC = m + n - 1;

            // Iterate to merge
            while (indexC >= 0 && indexB >= 0)
                nums1[indexC--] = indexA >= 0 && nums1[indexA] > nums2[indexB]
                    ? nums1[indexA--]
                    : nums2[indexB--];
        }
    }
}
