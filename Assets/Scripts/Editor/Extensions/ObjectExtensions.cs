using UnityEngine;

namespace Editor.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsPrefab(this Component component) 
            => component.gameObject.scene.rootCount == 0;
    }
}