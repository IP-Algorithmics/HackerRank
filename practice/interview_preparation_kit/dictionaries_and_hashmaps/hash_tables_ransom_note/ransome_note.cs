using System;
using System.Collections.Concurrent;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.dictionaries_and_hashmaps.hash_tables_ransom_note
{
    public static class RansomeNote
    {
        public static string checkMagazine(string[] magazine, string[] note)
        {
            // Concurrency dictionary affects performance but brings utility functions that were implemented in later versions of the .NetFramework which are currently unavailable for the online compiler
            var magazineDict = new ConcurrentDictionary<string,int>();
            foreach (var str in magazine)
            {
                magazineDict.AddOrUpdate(str, 1, (x, count) => count + 1);
            }

            var noteDictionary = new ConcurrentDictionary<string, int>();
            foreach (var str in note)
            {
                noteDictionary.AddOrUpdate(str, 1, (x, count) => count + 1);
            }

            var result = noteDictionary.All(x => magazineDict.ContainsKey(x.Key) && magazineDict[x.Key] >= x.Value);
            Console.WriteLine(result ? "Yes" : "No");

            return result ? "Yes" : "No";
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
            var result = RunTest(() => RansomeNote.checkMagazine(item2[0].ToArray(),item2[1].ToArray()));
            Assert.Equal("Yes", result.Item1);
        }

        [Fact]
        public void Test2()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input20.txt"));
            var result = RunTest(() => RansomeNote.checkMagazine(item2[0].ToArray(), item2[1].ToArray()));
            Assert.Equal("No", result.Item1);
        }

        [Fact]
        public void Test3()
        {
            var (item1, item2) = AlgorithmUtility.Run<int, string>(InputFilePath("input21.txt"));
            var result = RunTest(() => RansomeNote.checkMagazine(item2[0].ToArray(), item2[1].ToArray()));
            Assert.Equal("No", result.Item1);
        }
    }
}