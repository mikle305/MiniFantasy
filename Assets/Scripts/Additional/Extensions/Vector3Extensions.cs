using Data;
using UnityEngine;

namespace Additional.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3Data ToVectorData(this Vector3 vector)
        {
            return new Vector3Data
            {
                X = vector.x,
                Y = vector.y,
                Z = vector.z
            };
        }

        public static Vector3 ToUnityVector(this Vector3Data vectorData)
        {
            return new Vector3()
            {
                x = vectorData.X,
                y = vectorData.Y,
                z = vectorData.Z
            };
        }
    }
}