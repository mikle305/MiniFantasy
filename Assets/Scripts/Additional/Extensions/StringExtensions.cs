using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Additional.Extensions
{
    public static class StringExtensions
    {
        public static T FromJson<T>(this string jsonString) 
            => JsonUtility.FromJson<T>(jsonString);

        public static string ToJson<T>(this T obj) 
            => JsonUtility.ToJson(obj);
        
        public static string[] SplitByCapital(this string str)
            => Regex.Split(str, @"(?<!^)(?=[A-Z])");

        public static string ConvertToString(this IEnumerable<string> strings, string separator)
            => string.Join(separator, strings);
    }
}