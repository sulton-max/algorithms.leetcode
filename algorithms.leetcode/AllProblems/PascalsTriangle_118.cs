namespace PascalsTriangle_118;

public class Solution {
    public IList<IList<int>> Generate(int numRows)
    {
        (var pascalTraingle, var rowIndex) = (new List<int[]> { new[] { 1 } }, 1);
        while (rowIndex++ < numRows)
        {
            (var lastRow, var newRow) = (pascalTraingle.Last(), new List<int>{1, 1});
            for (var index = 0; index < lastRow.Length - 1; index++)
                newRow.Insert(index + 1, lastRow[index] + lastRow[index + 1]);
            pascalTraingle.Add(newRow.ToArray());
        }
        return pascalTraingle.ToArray();
    }
}