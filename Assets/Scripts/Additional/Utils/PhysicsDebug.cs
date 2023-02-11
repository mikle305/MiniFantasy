using UnityEngine;

namespace Additional.Utils
{
    public static class PhysicsDebug
    {
        
        public static void DrawSphere(Vector3 center, float radius, float time = 1.0f)
        {
            DrawSphere(center, radius, Color.red, time);
        }
        
        public static void DrawSphere(Vector3 center, float radius, Color color, float time = 1.0f)
        {
            Debug.DrawRay(center, radius * Vector3.up, color, time);
            Debug.DrawRay(center, radius * Vector3.down, color, time);
            Debug.DrawRay(center, radius * Vector3.left, color, time);
            Debug.DrawRay(center, radius * Vector3.right, color, time);
            Debug.DrawRay(center, radius * Vector3.forward, color, time);
            Debug.DrawRay(center, radius * Vector3.back, color, time);
        }
    }
}