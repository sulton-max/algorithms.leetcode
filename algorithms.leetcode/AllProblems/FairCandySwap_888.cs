namespace FairCandySwap_888
{
    public class Solution
    {
        public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
        {
            // Sort arrays
            Array.Sort(aliceSizes);
            Array.Sort(bobSizes);

            // Define which array is smaller to reduce time complexity, sArr - smaller, lArr - larger
            var (sArr, lArr) = aliceSizes.Length < bobSizes.Length
                ? (aliceSizes, bobSizes)
                : (bobSizes, aliceSizes);

            // Define both array sizes and calculate difference
            var sArrSize = 0;
            var lArrSize = 0;
            for (var index = 0; index < lArr.Length; index++)
            {
                lArrSize += lArr[index];
                sArrSize = (index < sArr.Length) ? sArrSize + sArr[index] : sArrSize;
            }
            var sArrDiff = sArrSize - (sArrSize + lArrSize)/2;

            // Iterate smaller array and binary search larger array to find box couples that satisfies difference
            for (var index = 0; index < sArr.Length; index++)
            {
                var startIndex = 0;
                var endIndex = lArr.Length;
                var targetIndex = default(int?);

                while (true)
                {
                    // Check the smallest subset
                    if (endIndex - startIndex == 1)
                    {
                        targetIndex = sArr[index] - lArr[startIndex] == sArrDiff
                            ? startIndex
                            : sArr[index] - lArr[endIndex] == sArrDiff ? endIndex : null;
                        break;
                    }

                    // Calculate median and check
                    var median = (endIndex - startIndex) / 2 + startIndex;
                    if (sArr[index] - lArr[median] == sArrDiff)
                    {
                        targetIndex = median;
                        break;
                    }

                    // Define either search forward or backward
                    var iterateForward = sArr[index] - lArr[median] > sArrDiff;
                    (startIndex, endIndex) = iterateForward ? (median, endIndex) : (startIndex, median);
                }

                if (targetIndex.HasValue)
                    return aliceSizes.Length < bobSizes.Length
                        ? new[] { sArr[index], lArr[targetIndex.Value] }
                        : new[] { lArr[targetIndex.Value], sArr[index] };
            }

            return new int[0];
        }
    }
}
