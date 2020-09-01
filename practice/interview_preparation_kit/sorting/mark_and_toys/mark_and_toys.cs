using System;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.sorting.mark_and_toys
{
    public static class MarkAndToys
    {
        public static int maximumToys(int[] prices, int k)
        {
            var sum = 0;
            var count = 0;
            prices = prices.OrderBy(x => x).ToArray();
            for (int i = 0; i < prices.Length; i++)
            {
                if (sum + prices[i] <= k)
                {
                    sum += prices[i];
                    count++;
                }
                else if (i > 1 && sum - prices[i - 1] + prices[i] <= k)
                {
                    sum = sum - prices[i - 1] + prices[i];
                }
                else
                {
                    break;
                }
            }

            return count;
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
            var (result, time) = RunTest(() => MarkAndToys.maximumToys(item2[0].ToArray(), item1[1]));
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test2()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, int>(InputFilePath("input2.txt"));
            var (result, time) = RunTest(() => MarkAndToys.maximumToys(item2[0].ToArray(), item1[1]));
            Assert.Equal(3, result);
        }
    }
}