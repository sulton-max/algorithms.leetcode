namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new MergeSortedArray_88.Solution();

            var test1 = new int[][] { new[] { 1, 2, 3, 0, 0, 0 }, new[] { 2, 5, 6 } };
            (var m1, var n1) = (3, 3);
            var test2 = new int[][] { new[] { 1 }, new int[0] };
            (var m2, var n2) = (1, 0);
            var test3 = new int[][] { new[] { 0 }, new[] { 1 } };
            (var m3, var n3) = (0, 1);

            solution.Merge(test1[0], m1, test1[1], n1);
            solution.Merge(test2[0], m2, test2[1], n2);
            solution.Merge(test3[0], m3, test3[1], n3);

            Console.ReadLine();
        }
    }
}
