using GamePlay.LootSystem;
using GamePlay.WeaponSystem;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class LootFactory : ILootFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public LootFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        
        public LootPiece CreateInWorld(LootId lootId, Vector3 position)
        {
            string prefabPath = _staticDataService.GetLootData(lootId).InWorldPrefabPath;
            return _assetProvider.Instantiate<LootPiece>(prefabPath, position);
        }

        public GameObject CreateInHolder(LootId lootId, ItemHolder itemHolder)
        {
            var lootData = _staticDataService.GetLootData<InventoryLootData>(lootId);
            return _assetProvider.Instantiate<GameObject>(lootData.InHolderPrefabPath, parent: itemHolder.transform);
        }
    }
}