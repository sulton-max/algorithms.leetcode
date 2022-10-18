using System;
using System.Collections.Generic;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new MaximumSubarray_53.Solution();
            var test1 = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var test2 = new[] { 1 };
            var test3 = new[] { 5, 4, -1, 7, 8 };
            var test4 = new[] { -2, -1 };

            Console.WriteLine(solution.MaxSubArray(test1));
            Console.WriteLine(solution.MaxSubArray(test2));
            Console.WriteLine(solution.MaxSubArray(test3));
            Console.WriteLine(solution.MaxSubArray(test4));
        }
    }
}