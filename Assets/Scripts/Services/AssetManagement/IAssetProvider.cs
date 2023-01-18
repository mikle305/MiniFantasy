using UnityEngine;

namespace Services.AssetManagement
{
    public interface IAssetProvider
    {
        public GameObject Instantiate(string path, Vector3? position = null, Transform parent = null);
        
        public T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T: Object;
    }
}