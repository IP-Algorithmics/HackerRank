using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerRank.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.practice.interview_preparation_kit.sorting.sorting_comparator
{
    public static class SortingComparator
    {
        public static List<Player> playerComparator(List<Player> list)
        {
            return list.OrderByDescending(x => x.Score).ThenByDescending(x => x.Name).ToList();
        }

    }

    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class Test : TestBase
    {
        public Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void Test1()
        {
            var lines = File.ReadAllLines(InputFilePath("input.txt"));

            var queries = new List<Player>();
            for (var i = 1; i < lines.Length; i++)
            {

                var dataArr = lines[i].Split(' ').ToList();
                queries.Add(new Player { Name = dataArr[0], Score = int.Parse(dataArr[1]) });
            }

            var result = SortingComparator.playerComparator(queries);
            result.ForEach(x => TestOutputHelper.WriteLine(x.Name + ' ' + x.Score));
        }
    }
}