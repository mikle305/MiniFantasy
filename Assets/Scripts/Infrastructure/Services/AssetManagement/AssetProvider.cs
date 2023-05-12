using DiContainer.UniDependencyInjection.Core.Unity;
using UniDependencyInjection.Core.Model;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        private readonly IContainer _container;

        public AssetProvider(IContainer container)
        {
            _container = container;
        }
        
        public GameObject Instantiate(string path, Vector3? position = null, Transform parent = null)
        {
            return Instantiate<GameObject>(path, position, parent);
        }

        public T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T: Object
        {
            var prefab = Resources.Load<T>(path);
            
            if (position == null && parent != null)
                return _container.Instantiate(prefab, parent, injectInChildren: true);
            
            if (position != null && parent == null)
                return _container.Instantiate(prefab, (Vector3)position, injectInChildren: true);
            
            if (position != null && parent != null)
                return _container.Instantiate(prefab, (Vector3)position, parent, injectInChildren: true);
            
            return _container.Instantiate(prefab, injectInChildren: true);
        }
    }
}