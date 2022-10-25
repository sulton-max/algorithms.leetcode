namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new FindTheDistanceValueBetweenTwoArrays_1385.Solution();

            var test1 = new int[][] { new[] { 4, 5, 8 }, new[] { 10, 9, 1, 8 } };
            var test2 = new int[][] { new[] { 1,4,2,3 }, new[] { -4,-3,6,10,20,30 } };
            var test3 = new int[][] { new[] { 2,1,100,3 }, new[] {-5,-2,10,-3,7 } };

            Console.WriteLine(solution.FindTheDistanceValue(test1[0], test1[1], 2));
            Console.WriteLine(solution.FindTheDistanceValue(test2[0], test2[1], 3));
            Console.WriteLine(solution.FindTheDistanceValue(test3[0], test3[1], 6));
            
            Console.ReadLine();
        }
    }
}