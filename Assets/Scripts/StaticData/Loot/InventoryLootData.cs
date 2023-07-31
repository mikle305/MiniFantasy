using GamePlay.InventorySystem;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Default", fileName = "LootData")]
    public class InventoryLootData : LootData
    {
        private const string _inHolderPrefabsFolder = "Prefabs/Loot/InHolder/";
        
        [Space(5)] [Header("Inventory")] [Space(3)]
        [SerializeField] private string _description;
        [SerializeField] private int _maxCountInSlot = 999;
        [SerializeField] private ItemRarity _itemRarity = ItemRarity.Common;


        public string InHolderPrefabPath => _inHolderPrefabsFolder + name;
        public string Description => _description;
        public int MaxCountInSlot => _maxCountInSlot;
        public ItemRarity ItemRarity => _itemRarity;
    }
}