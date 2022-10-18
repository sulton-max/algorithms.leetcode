namespace Sqrtx_69
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x < 2)
                return x;

            // Founding the nearest 2 points ( equal or between )
            double startIndex = 0;
            double endIndex = (int)(x / 2);
            while (true)
            {
                if (endIndex - startIndex == 1)
                    return (int)((endIndex * endIndex) <= x ? endIndex : startIndex);

                var median = (int)(endIndex - startIndex) / 2 + startIndex;
                if ((median * median) == x)
                    return (int)median;

                startIndex = ((median * median) < x) ? median : startIndex;
                endIndex = ((median * median) > x) ? median : endIndex;
            }
        }
    }
}
