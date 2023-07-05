using System;
using System.Collections.Generic;
using GamePlay.LootSystem;
using UnityEngine;

namespace GamePlay.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        private readonly Dictionary<LootId, Item> _items = new();

        public event Action<Item> ItemChanged;


        public void AddLoot(LootId lootId, int count)
        {
            if (_items.TryGetValue(lootId, out Item item))
            {
                item.Count += count;
            }
            else
            {
                item = new Item
                {
                    LootId = lootId,
                    Count = count,
                };
                _items.Add(lootId, item);
            }
            
            ItemChanged?.Invoke(item);
        }
    }
}