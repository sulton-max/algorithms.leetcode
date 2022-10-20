namespace GuessNumberHigherOrLower_374
{
    public class GuessGame
    {
        public int guess(int num) => num == 2 ? 0 : num > 2 ? -1 : 1;
    }

    public class Solution : GuessGame
    {
        public int GuessNumber(int n)
        {
            if (n <= 1)
                return n;

            // Define upper and lower bounds
            var startIndex = 0;
            var endIndex = n;

            while(true)
            {
                // Check if search ended
                if (endIndex - startIndex == 1)
                    return guess(startIndex) == 0 ? startIndex : endIndex;

                // Calculate median and check
                var median = (endIndex - startIndex) / 2 + startIndex;
                var result = guess(median);

                if (result == 0)
                    return median;

                (startIndex, endIndex) = result == -1 ? (startIndex, median) : (median, endIndex);
            }
        }
    }
}
