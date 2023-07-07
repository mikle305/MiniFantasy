using GamePlay.LootSystem;
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
        
        public LootPiece CreateInWorld(LootId lootId, Vector3 position)
        {
            string prefabPath = _staticDataAccess.FindLootData(lootId).PrefabPath;
            return _assetProvider.Instantiate<LootPiece>(prefabPath, position);
        }

        public GameObject CreateInUi(LootId lootId, RectTransform parent)
        {
            string iconPath = _staticDataAccess.FindLootData(lootId).IconPath;
            return _assetProvider.Instantiate<GameObject>(iconPath, parent.position, parent);
        }
    }
}