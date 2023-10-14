using UniDependencyInjection.Unity;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ResourcesAssetProvider : AssetProvider
    {
        public ResourcesAssetProvider(IMonoResolver assetProvider) 
            : base(assetProvider) { }

        public override T Load<T>(string path) 
            => Resources.Load<T>(path);

        public override T[] LoadMany<T>(string path) 
            => Resources.LoadAll<T>(path);
    }
}