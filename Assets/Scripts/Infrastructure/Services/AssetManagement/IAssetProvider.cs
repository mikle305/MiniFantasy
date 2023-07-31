using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider
    {
        public T Instantiate<T>(string path,
            Vector3? position = null,
            Transform parent = null,
            bool injectInChildren = true) 
            where T : Object;

        public T Load<T>(string path) where T : Object;
        
        public T[] LoadMany<T>(string path) where T : Object;
    }
}