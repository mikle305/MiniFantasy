using GamePlay.InventorySystem;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Inventory", fileName = "LootData")]
    public class InventoryLootData : LootStaticData
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _maxCountInSlot = 999;
        [SerializeField] private ItemUseType _itemUseType = ItemUseType.None;
        [SerializeField] private ItemRarity _itemRarity = ItemRarity.Common;


        public string Name => _name;
        public string Description => _description;
        public int MaxCountInSlot => _maxCountInSlot;
        public ItemUseType UseType => _itemUseType;
        public ItemRarity ItemRarity => _itemRarity;
    }
}