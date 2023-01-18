using UnityEngine;

namespace Additional.Extensions
{
    public static class StringExtensions
    {
        public static T Deserialize<T>(this string jsonString) => JsonUtility.FromJson<T>(jsonString);
    }
}