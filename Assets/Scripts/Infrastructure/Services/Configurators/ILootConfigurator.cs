using GamePlay.Units.Loot;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ILootConfigurator
    {
        public void Configure(LootPiece lootPiece, LootTypeId lootId);
    }
}