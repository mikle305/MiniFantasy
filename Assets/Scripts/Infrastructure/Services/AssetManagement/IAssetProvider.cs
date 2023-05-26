using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider
    {
        public T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T : Object;
    }
}