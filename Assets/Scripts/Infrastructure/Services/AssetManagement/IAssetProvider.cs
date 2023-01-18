using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    public interface IAssetProvider : IService
    {
        public GameObject Instantiate(string path, Vector3? position = null, Transform parent = null);

        public T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T : Object;
    }
}