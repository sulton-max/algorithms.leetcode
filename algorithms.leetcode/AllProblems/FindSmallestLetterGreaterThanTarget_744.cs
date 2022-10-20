namespace FindSmallestLetterGreaterThanTarget_744
{
    public class Solution
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            // Define upper and lower boundaries
            var startIndex = 0;
            var endIndex = letters.Length;

            while(true)
            {
                // Check smallest subset
                if (endIndex - startIndex == 1)
                    return letters[startIndex] > target
                        ? letters[startIndex]
                        : endIndex < letters.Length && letters[endIndex] > target
                            ? letters[endIndex] : letters[0];

                // Calculate and check median
                var median = (endIndex - startIndex) / 2 + startIndex;
                if (letters[median] > target && letters[median - 1] < target)
                    return letters[median];

                (startIndex, endIndex) = letters[median] <= target ? (median, endIndex) : (startIndex, median);
            }
        }
    }
}
