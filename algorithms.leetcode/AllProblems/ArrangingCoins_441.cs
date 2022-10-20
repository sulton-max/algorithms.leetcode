namespace ArrangingCoins_441
{
    public class Solution
    {
        public int ArrangeCoins(int n)
        {
            if (n < 2)
                return n == 1 ? 1 : 0;

            // Define upper and lower boundaries
            var startIndex = 1D;
            var endIndex = (double)n;

            while(true)
            {
                if (endIndex - startIndex == 1)
                    return (int)(GetRowSum(endIndex) > n ? startIndex : startIndex - 1);

                // Calculate the median and the sum of the items needed
                var median = (int)((endIndex - startIndex) / 2) + startIndex;
                var sum = GetRowSum(median);
                if (sum == n)
                    return (int)median;

                (startIndex, endIndex) = sum < n ? (median, endIndex) : (startIndex, median);
            }
        }

        public double GetRowSum(double value)
        {
            return (value + value * value) / 2;
        }
    }
}
