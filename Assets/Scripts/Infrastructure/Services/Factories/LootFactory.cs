using Infrastructure.Services;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace GamePlay.Loot
{
    public class LootFactory : ILootFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataAccess _staticDataAccess;

        public LootFactory(IAssetProvider assetProvider, IStaticDataAccess staticDataAccess)
        {
            _assetProvider = assetProvider;
            _staticDataAccess = staticDataAccess;
        }
        
        public GameObject Create(LootTypeId lootTypeId, Vector3 position, Transform parent)
        {
            string prefabPath = _staticDataAccess.FindLootData(lootTypeId).PrefabPath;
            return _assetProvider.Instantiate<GameObject>(prefabPath, position, parent);
        }
    }
}