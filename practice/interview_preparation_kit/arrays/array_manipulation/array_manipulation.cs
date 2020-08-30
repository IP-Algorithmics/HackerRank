using System;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.arrays.array_manipulation
{
    public static class ArrayManipulation
    {
      
        public static long arrayManipulationNaive(int n, int[][] queries) {
            var arr = new long[n];
            Array.Fill(arr,0);
            foreach (var query in queries)
            {
                for (var i = query[0]; i < query[1]; i++)
                {
                    arr[i] += query[2];
                }
            }

            return arr.Max();
        }

        public static long arrayManipulation(int n, int[][] queries) {
            var arr = new long[n + 1];
            foreach (var query in queries)
            {
                arr[query[0] - 1] += query[2];
                arr[query[1]]   -= query[2];
            }
            long sum = 0;
            long max = 0;
            for (var i = 0; i < n; i++) {
                sum += arr[i];
                max = Math.Max(max, sum);
            }
            return max;
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
            var (item1, item2) = AlgorithmUtility.Run<int, int>(InputFilePath("test_case_12.txt"));
            RunTest(() => ArrayManipulation.arrayManipulation(item1[0],item2.Select(x => x.ToArray()).ToArray()));
        }

        [Fact]
        public void TestNaive()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, int>(InputFilePath("test_case_12.txt"));
            RunTest(() => ArrayManipulation.arrayManipulationNaive(item1[0], item2.Select(x => x.ToArray()).ToArray()));
        }
    }
}