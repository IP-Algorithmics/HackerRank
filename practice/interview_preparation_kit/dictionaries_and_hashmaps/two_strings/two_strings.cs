using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.dictionaries_and_hashmaps.two_strings
{
    public static class TwoStrings
    {
        public static string twoStrings(string s1, string s2)
        {
            // Concurrency dictionary affects performance but brings utility functions that were implemented in later versions of the .NetFramework which are currently unavailable for the online compiler
            var s1Dict = new ConcurrentDictionary<string,int>(); 
            var s2Dict = new ConcurrentDictionary<string, int>();

            foreach (var c1 in s1)
            {
                s1Dict.TryAdd(c1.ToString(),0);
            }
            foreach (var c2 in s2)
            {
                s2Dict.TryAdd(c2.ToString(), 0);
            }

            var result = s1Dict.Any(x => s2Dict.ContainsKey(x.Key));
            return result ? "YES" : "NO";
        }

        public static string twoStringsNaive(string s1, string s2)
        {
            var result = s1.Any(s2.Contains);
            return result ? "YES" : "NO";
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
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input.txt"));
            var result = new List<string>();
            for (var i = 0; i < item2.Count - 1; i += 2)
            {
                result.Add(RunTest(() => TwoStrings.twoStrings(item2[i][0], item2[i + 1][0])).Item1);
            }
            Assert.Equal("YES", result[0]);
            Assert.Equal("NO", result[1]);
        }

        [Fact]
        public void TestNaive()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input.txt"));
            var result = new List<string>();
            for (var i = 0; i < item2.Count - 1; i += 2)
            {
                result.Add(RunTest(() => TwoStrings.twoStringsNaive(item2[i][0], item2[i + 1][0])).Item1);
            }
            Assert.Equal("YES", result[0]);
            Assert.Equal("NO", result[1]);
        }
    }
}