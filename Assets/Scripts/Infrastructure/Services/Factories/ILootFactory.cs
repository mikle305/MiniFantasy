using Infrastructure.Services.StaticData;
using UnityEngine;

namespace GamePlay.Loot
{
    public interface ILootFactory
    {
        public GameObject Create(LootTypeId lootTypeId, Vector3 position, Transform parent);
    }
}