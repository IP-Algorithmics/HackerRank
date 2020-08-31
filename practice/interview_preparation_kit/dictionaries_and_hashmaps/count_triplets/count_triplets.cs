using System;
using System.Collections.Generic;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.dictionaries_and_hashmaps.count_triplets
{
    public static class CountTriplets
    {
        public static long countTriplets(List<long> arr, long r)
        {
            long count = 0;
            var dict = new Dictionary<long, long>();
            var dictPair = new Dictionary<long, long>();

            foreach (var element in arr)
            {

                if (dictPair.ContainsKey(element))
                {
                    count += dictPair[element];
                }

                if (dictPair.ContainsKey(element * r))
                {
                    if (dict.ContainsKey(element))
                    {
                        dictPair[element * r] += dict[element];
                    }
                }
                else
                {
                    dictPair.Add(element * r, 1);
                }

                if (dict.ContainsKey(element * r))
                {
                    dict[element * r] += 1;
                }
                else
                {
                    dict.Add(element * r, 1);
                }
            }

            return count;
        }

        public static long countTripletsNaive(List<long> arr, long r)
        {
            arr = arr.OrderBy(x => x).ToList();

            var count = 0;
            for (var i = 0; i <= arr.Count - 3; i++)
            {
                for (var j = i + 1; j <= arr.Count - 2; j++)
                {
                    for (var k = j + 1; k <= arr.Count - 1; k++)
                    {
                        if (isGeometricSequence(arr[i], arr[j], arr[k], r))
                        {
                            count++;
                        }
                    }
                }

            }

            return count;
        }

        private static bool isGeometricSequence(long x, long y, long z, long ratio)
        {
            return x * ratio == y && y * ratio == z;
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
            var (item1, item2) = AlgorithmUtility.Run<long, long>(InputFilePath("input.txt"));
            var result = RunTest(() => CountTriplets.countTriplets(item2[0], item1[1])).Item1;
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            var (item1, item2) = AlgorithmUtility.Run<long, long>(InputFilePath("input2.txt"));
            var result = RunTest(() => CountTriplets.countTriplets(item2[0], item1[1])).Item1;
            Assert.Equal(4, result);
        }

        [Fact]
        public void TestNaive()
        {
            var (item1, item2) = AlgorithmUtility.Run<long, long>(InputFilePath("input.txt"));
            var result = RunTest(() => CountTriplets.countTripletsNaive(item2[0], item1[1])).Item1;
            Assert.Equal(6, result);
        }
    }
}