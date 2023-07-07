using System;
using System.Linq;
using GamePlay.LootSystem;
using StaticData;
using UnityEngine;

namespace GamePlay.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _slotsCount = 24;
        
        private Slot[] _slots;

        public event Action<Slot[]> SlotsAdded;


        private void Start()
        {
            _slots = new Slot[_slotsCount];
            for (var i = 0; i < _slotsCount; i++) 
                _slots[i] = new Slot();

            SlotsAdded?.Invoke(_slots);
        }
        
        public bool CanAddLoot(InventoryLootData lootData)
        {
            foreach (Slot slot in _slots)
            {
                if (slot.ItemId == LootId.None)
                    return true;

                if (slot.ItemId == lootData.LootId && !slot.IsFull())
                    return true;
            }

            return false;
        }

        public int AddLoot(InventoryLootData lootData, int count)
        {
            int remainsCount = DistributeToExist(lootData, count);
            if (remainsCount == 0)
                return 0;
            
            remainsCount = DistributeToEmpty(lootData, remainsCount);
            return remainsCount;
        }

        /// <summary>
        /// Distributes loot to empty slots
        /// Returns remains count.
        /// </summary>
        private int DistributeToEmpty(InventoryLootData lootData, int count)
        {
            int maxCountInSlot = lootData.MaxCountInSlot;
            foreach (Slot emptySlot in _slots.Where(s => s.ItemId == LootId.None))
            {
                if (count == 0)
                    return count;
                
                int countToSet = count > maxCountInSlot
                    ? maxCountInSlot
                    : count;
                
                count -= countToSet;
                
                emptySlot.TrySetItem(new Item(lootData, countToSet));
            }

            return count;
        }

        /// <summary>
        /// Distributes loot to slots, which already have this type of loot loot.
        /// Returns remains count.
        /// </summary>
        private int DistributeToExist(InventoryLootData lootData, int count)
        {
            foreach (Slot slot in _slots.Where(slot => slot.ItemId == lootData.LootId))
            {
                count = slot.AddCount(count);
                if (count == 0)
                    return 0;
            }

            return count;
        }
    }
}