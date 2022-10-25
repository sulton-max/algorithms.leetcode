namespace CheckIfNAndItsDoubleExist_1346
{
    public class Solution
    {
        public bool CheckIfExist(int[] arr)
        {
            Array.Sort(arr);

            // Iterate to binary search
            for (var index = 0; index < arr.Length; index++)
            {
                (var startIndex, var endIndex, var equals) = (index + 1, arr.Length, false);
                while (startIndex < arr.Length)
                {
                    if (endIndex - startIndex == 1)
                    {
                        equals = Equals(arr[startIndex], arr[index]) ? true : endIndex < arr.Length && Equals(arr[endIndex], arr[index]);
                        break;
                    }

                    var median = (endIndex - startIndex) / 2 + startIndex;
                    if (Equals(arr[median], arr[index]))
                    {
                        equals = true;
                        break;
                    }

                    (startIndex, endIndex) = (arr[index] < 0 && arr[index] > arr[median] * 2) || (arr[index] > 0 && arr[index] * 2 > arr[median]) 
                        ? (median, endIndex) 
                        : (startIndex, median);
                }

                if (equals)
                    return true;
            }
            
            return false;
        }

        public bool Equals(int valueA, int valueB) => valueA == 2 * valueB || valueB == 2 * valueA;
    }
}
