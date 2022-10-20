namespace FirstBadVersion_278
{
    public class VersionControl
    {
        public bool IsBadVersion(int version) => version >= 4;
    }

    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            if (n == 1)
                return IsBadVersion(n) ? n : -1;

            var startIndex = 1;
            var endIndex = n;

            while (true)
            {
                if (endIndex - startIndex == 1)
                    return IsBadVersion(startIndex) ? startIndex : startIndex + 1;

                var median = (endIndex - startIndex) / 2 + startIndex;
                var isMedianBad = IsBadVersion(median);
                startIndex = (isMedianBad) ? startIndex : median;
                endIndex = (!isMedianBad) ? endIndex : median;
            }
        }
    }
}
