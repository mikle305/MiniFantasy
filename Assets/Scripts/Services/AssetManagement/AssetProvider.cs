using UnityEngine;

namespace Services.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Vector3? position = null, Transform parent = null)
        {
            return Instantiate<GameObject>(path, position, parent);
        }

        public T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T: Object
        {
            var prefab = Resources.Load<T>(path);
            
            if (position == null && parent != null)
                return Object.Instantiate(prefab, parent);
            
            if (position != null && parent == null)
                return Object.Instantiate(prefab, (Vector3)position, Quaternion.identity);
            
            if (position != null && parent != null)
                return Object.Instantiate(prefab, (Vector3)position, Quaternion.identity, parent);
            
            return Object.Instantiate(prefab);
        }
    }
}