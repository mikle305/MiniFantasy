using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            IEnumerable<T> collection = enumeration as T[] ?? enumeration.ToArray();
            foreach(T item in collection) 
                action.Invoke(item);

            return collection;
        }
    }
}