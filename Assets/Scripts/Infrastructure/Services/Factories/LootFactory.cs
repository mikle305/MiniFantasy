using GamePlay.LootSystem;
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
            string prefabPath = _staticDataService.FindLootData(lootId).PrefabPath;
            return _assetProvider.Instantiate<LootPiece>(prefabPath, position);
        }

        public GameObject CreateInUi(LootId lootId, RectTransform parent)
        {
            string iconPath = _staticDataService.FindLootData(lootId).IconPath;
            return _assetProvider.Instantiate<GameObject>(iconPath, parent.position, parent);
        }
    }
}