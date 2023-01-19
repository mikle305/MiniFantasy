using UnityEngine;

namespace Additional.Extensions
{
    public static class StringExtensions
    {
        public static T FromJson<T>(this string jsonString) => JsonUtility.FromJson<T>(jsonString);

        public static string ToJson<T>(this T obj) => JsonUtility.ToJson(obj);
    }
}