namespace TheKWeakestRowsInAMatrix_1337
{
    public class Solution
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            // Iterate to find calculate sums

            var sums = new int[mat.Length][];
            for (var index = 0; index < mat.Length; index++)
            {
                (var startIndex, var endIndex, var targetIndex) = (0, mat[0].Length, default(int?));

                if (mat[index][mat[0].Length - 1] != 1)
                    while (true)
                    {
                        // Check if the minimum subset is reached
                        if (endIndex - startIndex == 1)
                        {
                            targetIndex = mat[index][startIndex] == 1 && (startIndex == mat.Length - 1 || mat[index][startIndex + 1] == 0)
                                ? startIndex
                                : endIndex < mat[index].Length && mat[index][endIndex] == 1 ? endIndex : null;
                            break;
                        }

                        // Calculate median and check
                        var median = (endIndex - startIndex) / 2 + startIndex;
                        if (mat[index][median] == 1 && (median == mat[index].Length - 1 || mat[index][median + 1] == 0))
                        {
                            targetIndex = median;
                            break;
                        }

                        // Recalculate boundaries
                        (startIndex, endIndex) = mat[index][median] == 1 ? (median, endIndex) : (startIndex, median);
                    }
                else
                    targetIndex = mat[0].Length - 1;

                var sum = targetIndex.HasValue ? targetIndex.Value + 1 : 0;
                sums[index] = new[] { index, sum };
            }

            // Iterate to sort
            for (var indexA = 0; indexA < sums.Length; indexA++)
                for (var indexB = indexA + 1; indexB < sums.Length; indexB++)
                {
                    if (sums[indexB][1] < sums[indexA][1] 
                        || sums[indexB][1] == sums[indexA][1] && sums[indexB][0] < sums[indexA][0])
                    {
                        (var index, var value) = (sums[indexB][0], sums[indexB][1]);
                        (sums[indexB][0], sums[indexB][1]) = (sums[indexA][0], sums[indexA][1]);
                        (sums[indexA][0], sums[indexA][1]) = (index, value);
                    }
                }

            var result = new int[k];
            Array.Copy(sums.Select(x => x[0]).ToArray(), result, k);
            return result;
        }
    }
}
