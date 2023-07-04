using GamePlay.Units.Loot;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILootFactory
    {
        public LootPiece Create(LootTypeId lootTypeId, Vector3 position);
    }
}