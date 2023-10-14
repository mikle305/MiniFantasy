using GamePlay.LootSystem;
using GamePlay.WeaponSystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILootFactory
    {
        public LootPiece CreateInWorld(LootId lootId, Vector3 position);
        GameObject CreateInHolder(LootId lootId, ItemHolder itemHolder);
    }
}