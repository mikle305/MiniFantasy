using GamePlay;
using GamePlay.LootSystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILootFactory
    {
        public LootPiece Create(LootId lootId, Vector3 position);
    }
}