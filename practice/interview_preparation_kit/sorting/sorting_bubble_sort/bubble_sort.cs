using System;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.sorting.sorting_bubble_sort
{
    public static class BubbleSort
    {
        public static Tuple<int, int, int> countSwaps(int[] a)
        {
            var swaps = 0;
            for (int i = 0; i < a.Length; i++)
            {

                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        swap(ref a[j], ref a[j + 1]);
                        swaps++;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {a.First()}");
            Console.WriteLine($"Last Element: {a.Last()}");

            return new Tuple<int, int, int>(swaps, a.First(), a.Last());
        }

        private static void swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }


    }

    public class Test : TestBase
    {
        public Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void Test1()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, int>(InputFilePath("input.txt"));
            var (result,time) = RunTest(() => BubbleSort.countSwaps(item2[0].ToArray()));
            Assert.Equal("Array is sorted in 3 swaps.", $"Array is sorted in {result.Item1} swaps.");
            Assert.Equal("First Element: 1", $"First Element: { result.Item2}");
            Assert.Equal("Last Element: 3", $"Last Element: {result.Item3}");
        }
    }
}