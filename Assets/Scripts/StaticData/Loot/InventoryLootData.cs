using GamePlay.InventorySystem;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Default", fileName = "LootData")]
    public class InventoryLootData : LootStaticData
    {
        [SerializeField] private string _description;
        [SerializeField] private int _maxCountInSlot = 999;
        [SerializeField] private ItemRarity _itemRarity = ItemRarity.Common;
        
        
        public string Name => name;
        public string Description => _description;
        public int MaxCountInSlot => _maxCountInSlot;
        public ItemRarity ItemRarity => _itemRarity;
    }
}