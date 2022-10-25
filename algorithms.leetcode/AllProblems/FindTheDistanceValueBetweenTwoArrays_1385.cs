namespace FindTheDistanceValueBetweenTwoArrays_1385;

public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        (var list1, var list2) = (arr1.ToList(), arr2.ToList());
        return list1.Where(x => list2.TrueForAll(y => Math.Abs(x - y) > d)).Count();
    }
}