using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace HackerRank.Utilities
{
    public static class AlgorithmUtility
    {

        public static Tuple<List<TInit>, List<List<TData>>> Run<TInit,TData>(string path)
        {
            var lines = File.ReadAllLines(path);
            var initialData = lines[0].Split(' ').Select(ChangeType<TInit>).ToList();

            var queries = new List<List<TData>>();
            for (var i = 1; i < lines.Length; i++)
            {

                var dataArr = lines[i].Split(' ').Select(ChangeType<TData>).ToList();
                queries.Add(dataArr);
            }

            return new Tuple<List<TInit>, List<List<TData>>>(initialData, queries);
        }

        public static T ChangeType<T>(object value)
        {
            return (T)ChangeType(typeof(T), value);
        }

        public static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }

        public static void RegisterTypeConverter<T, TC>() where TC : TypeConverter
        {

            TypeDescriptor.AddAttributes(typeof(T), new TypeConverterAttribute(typeof(TC)));
        }
    }
}