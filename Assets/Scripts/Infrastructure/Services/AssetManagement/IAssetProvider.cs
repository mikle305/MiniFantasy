using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider
    {
        public T Instantiate<T>(string prefabPath) 
            where T : Object;

        public T Instantiate<T>(
            string prefabPath, 
            Transform parent,
            bool worldPositionStays = false) 
            where T : Object;

        public T Instantiate<T>(
            string prefabPath,
            Vector3 position,
            Quaternion rotation) 
            where T : Object;

        public T Instantiate<T>(
            string prefabPath,
            Vector3 position,
            Quaternion rotation,
            Transform parent) 
            where T : Object;

        public T Load<T>(string path) where T : Object;
        
        public T[] LoadMany<T>(string path) where T : Object;
    }
}