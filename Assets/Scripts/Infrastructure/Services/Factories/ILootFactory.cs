using GamePlay.LootSystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILootFactory
    {
        public LootPiece CreateInWorld(LootId lootId, Vector3 position);
    }
}