using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace HackerRank.practice.interview_preparation_kit.arrays.array_manipulation
{
    public static class ArrayManipulation
    {
        public static long Start(string path)
        {
            var lines = File.ReadAllLines(path);
            var initialData = lines[0].Split(' ').Select(int.Parse).ToList();
            var queries = new List<int[]>();
            for (var i = 1; i < lines.Length; i++)
            {
                var dataArr = lines[i].Split(' ').Select(int.Parse).ToArray();
                queries.Add(dataArr);
            }

            return arrayManipulation(initialData[0], queries.ToArray());
        }
        
        static long arrayManipulationNaive(int n, int[][] queries) {
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
        
        static long arrayManipulation(int n, int[][] queries) {
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

    public class Test
    {
        private string relativePath = typeof(ArrayManipulation).Namespace.Replace("HackerRank","").Replace(".","/");
        [Fact]
        public void TestNaive()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = ArrayManipulation.Start($"./{relativePath}/test_case_12.txt");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Assert.True(elapsedMs < 5000000000);
        }
        
        [Fact]
        public void Test1()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = ArrayManipulation.Start($"./{relativePath}/test_case_12.txt");
            watch.Stop();
            
            Debug.WriteLine(result);
            Debug.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}