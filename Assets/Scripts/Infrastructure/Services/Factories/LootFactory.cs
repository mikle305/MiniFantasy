using GamePlay.Units.Loot;
using UnityEngine;

namespace Infrastructure.Services
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
        
        public LootPiece Create(LootTypeId lootTypeId, Vector3 position)
        {
            string prefabPath = _staticDataAccess.FindLootData(lootTypeId).PrefabPath;
            return _assetProvider.Instantiate<LootPiece>(prefabPath, position);
        }
    }
}