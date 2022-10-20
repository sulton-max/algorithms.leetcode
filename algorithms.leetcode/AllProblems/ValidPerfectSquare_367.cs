namespace ValidPerfectSquare_367
{
    public class Solution
    {
        public bool IsPerfectSquare(int num)
        {
            if (num <= 1)
                return num == 1;

            // Define start and end index
            var startIndex = 1D;
            var endIndex = (double)(int)(num / 2);

            while (true)
            {
                if (endIndex - startIndex == 1)
                    return startIndex * startIndex == num
                        ? true
                        : endIndex * endIndex == num;

                // Calculate median and check
                var median = (int)((endIndex - startIndex) / 2) + startIndex;
                if (median * median == num)
                    return true;

                // Adjust upper and lower bounds
                var medianIsGreater = median * median > num;
                startIndex = !medianIsGreater ? median : startIndex;
                endIndex = medianIsGreater ? median : endIndex;
            }
        }
    }
}
