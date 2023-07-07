using System;
using UniDependencyInjection.Core;
using UniDependencyInjection.Unity;
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

            T created;
            if (position == null && parent != null)
                created = _container.Instantiate(prefab, parent, injectInChildren: injectInChildren);

            else if (position != null && parent == null)
                created = _container.Instantiate(prefab, (Vector3)position, injectInChildren: injectInChildren);
            
            else if (position != null && parent != null)
                created = _container.Instantiate(prefab, (Vector3)position, parent, injectInChildren: injectInChildren);
            else
                created = _container.Instantiate(prefab, injectInChildren: injectInChildren);

            SetRotationToCreated(created, prefab);
            return created;
        }

        public T Load<T>(string path) where T : Object 
            => Resources.Load<T>(path);

        public T[] LoadMany<T>(string path) where T : Object 
            => Resources.LoadAll<T>(path);

        private static void SetRotationToCreated<T>(T created, T prefab) where T : Object
        {
            switch (created)
            {
                case Component createdComponent when prefab is Component prefabComponent:
                    createdComponent.transform.localRotation = prefabComponent.transform.localRotation;
                    break;
                case Component createdComponent:
                {
                    if (prefab is GameObject prefabObject)
                        createdComponent.transform.localRotation = prefabObject.transform.localRotation;
                    break;
                }
                case GameObject createdObject when prefab is Component prefabComponent:
                    createdObject.transform.localRotation = prefabComponent.transform.localRotation;
                    break;
                case GameObject createdObject:
                {
                    if (prefab is GameObject prefabObject)
                        createdObject.transform.localRotation = prefabObject.transform.localRotation;
                    break;
                }
            }
        }
    }
}