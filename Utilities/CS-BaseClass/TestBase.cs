using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit.Abstractions;

namespace HackerRank.Utilities
{

    public abstract class TestBase
    {
        protected readonly ITestOutputHelper TestOutputHelper;
        protected readonly string SolutionName = System.Reflection.Assembly.GetExecutingAssembly()?.GetName().Name;
        protected readonly string RelativeAssemblyPath;

        protected TestBase(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;
            // get the path to the input file dynamically using the namespace of the class
            RelativeAssemblyPath = GetType().Namespace?.Replace(SolutionName, "").Replace(".", "/");
        }

        protected string InputFilePath(string fileName)
        {
            return $"./{RelativeAssemblyPath}/{fileName}";
        }

        public Tuple<T,long> RunTest<T>(string fileName, Func<string,T> func)
        {
            var watch = Stopwatch.StartNew();
            var result = func($"./{RelativeAssemblyPath}/{fileName}");
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            watch.Stop();

            TestOutputHelper.WriteLine(result.ToString());
            TestOutputHelper.WriteLine(elapsedMilliseconds.ToString());

            return new Tuple<T, long>(result, elapsedMilliseconds);
        }

        public Tuple<T, long> RunTest<T>(Func<T> func)
        {
            var watch = Stopwatch.StartNew();
            var result = func();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            watch.Stop();

            TestOutputHelper.WriteLine(result.ToString());
            TestOutputHelper.WriteLine(elapsedMilliseconds.ToString());

            return new Tuple<T, long>(result, elapsedMilliseconds);
        }
    }
}