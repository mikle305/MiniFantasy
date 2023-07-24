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
            string prefabPath = _staticDataService.GetLootData(lootId).PrefabPath;
            return _assetProvider.Instantiate<LootPiece>(prefabPath, position);
        }
    }
}