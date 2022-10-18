namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new MissingNumber_268.Solution();
            var test1 = new[] { 3, 0, 1 };
            var test2 = new[] { 0, 1 };
            var test3 = new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

            Console.WriteLine(solution.MissingNumber(test1));
            Console.WriteLine(solution.MissingNumber(test2));
            Console.WriteLine(solution.MissingNumber(test3));
        }
    }
}