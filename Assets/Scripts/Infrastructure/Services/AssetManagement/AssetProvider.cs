using UniDependencyInjection;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace Infrastructure.Services
{
    public abstract class AssetProvider : IAssetProvider
    {
        private readonly IMonoResolver _monoResolver;

        protected AssetProvider(IMonoResolver monoResolver)
        {
            _monoResolver = monoResolver;
        }
        
        public T Instantiate<T>(string prefabPath) where T : Object
        {
            var prefab = Load<T>(prefabPath);
            return _monoResolver.Instantiate(prefab);
        }
        
        public T Instantiate<T>(
            string prefabPath, 
            Transform parent,
            bool worldPositionStays = false) where T : Object
        {
            var prefab = Load<T>(prefabPath);
            return _monoResolver.Instantiate(prefab, parent, worldPositionStays);
        }
        
        public T Instantiate<T>(
            string prefabPath,
            Vector3 position,
            Quaternion rotation) where T : Object
        {
            var prefab = Load<T>(prefabPath);
            return _monoResolver.Instantiate(prefab, position, rotation);
        }
        
        public T Instantiate<T>(
            string prefabPath,
            Vector3 position,
            Quaternion rotation,
            Transform parent) where T : Object
        {
            var prefab = Load<T>(prefabPath);
            return _monoResolver.Instantiate(prefab, position, rotation, parent);
        }

        public abstract T Load<T>(string path) where T : Object;
        
        public abstract T[] LoadMany<T>(string path) where T : Object;
    }
}