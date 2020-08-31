using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.dictionaries_and_hashmaps.sherlock_and_anagrams
{
    public static class SherlockAndAnagrams
    {
        public static int sherlockAndAnagrams(string str)
        {
            var result = 0;

            for (var i = 1; i <= str.Length - 1; i++)
            {
                var dict = new Dictionary<string, int>();

                for (var j = 0; j <= str.Length - i ; j++)
                {
                    var key = new string(str.Substring(j, i).OrderBy(x => x).ToArray());

                    if (!dict.ContainsKey(key))
                        dict.Add(key, 1);
                    else
                        dict[key] += 1;
                }
                dict.Values.Where(x => x > 1).ToList().ForEach(value => { result += value * (value - 1) / 2; });
            }

            return result;
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
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input00.txt"));
            var result = new List<int>();
            for (var i = 0; i < item1[0] ; i++)
            {
                result.Add(RunTest(() => SherlockAndAnagrams.sherlockAndAnagrams(item2[i][0])).Item1);
            }
            Assert.Equal(4, result[0]);
            Assert.Equal(0, result[1]);
        }

        [Fact]
        public void Test2()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input01.txt"));
            var result = new List<int>();
            for (var i = 0; i < item1[0]; i++)
            {
                result.Add(RunTest(() => SherlockAndAnagrams.sherlockAndAnagrams(item2[i][0])).Item1);
            }
            Assert.Equal(3, result[0]);
            Assert.Equal(10, result[1]);
        }

        [Fact]
        public void Test3()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input06.txt"));
            var result = RunTest(() => SherlockAndAnagrams.sherlockAndAnagrams(item2[0][0])).Item1;
            Assert.Equal(5, result);
        }
    }
}