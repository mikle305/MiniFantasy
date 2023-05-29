using System;
using DiContainer.UniDependencyInjection.Core.Unity;
using UniDependencyInjection.Core.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        private readonly IContainer _container;

        public AssetProvider(IContainer container)
        {
            _container = container;
        }

        public T Instantiate<T>(
            string path, 
            Vector3? position = null, 
            Transform parent = null, 
            bool injectInChildren = true) 
            where T: Object
        {
            var prefab = Resources.Load<T>(path);
            if (prefab == null)
                throw new InvalidOperationException($"Object not found in resources, path: {path}");

            if (position == null && parent != null)
                return _container.Instantiate(prefab, parent, injectInChildren: injectInChildren);
            
            if (position != null && parent == null)
                return _container.Instantiate(prefab, (Vector3)position, injectInChildren: injectInChildren);
            
            if (position != null && parent != null)
                return _container.Instantiate(prefab, (Vector3)position, parent, injectInChildren: injectInChildren);
            
            return _container.Instantiate(prefab, injectInChildren: injectInChildren);
        }
    }
}