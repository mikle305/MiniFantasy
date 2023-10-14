using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.LootSystem;
using StaticData;
using UnityEngine;

namespace GamePlay.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        private Slot[] _slots;
        
        public event Action<Slot[]> SlotsAdded;


        public void Init(Slot[] slots)
        {
            _slots = slots;
            SlotsAdded?.Invoke(_slots);
        }
        
        public bool CanAddLoot(InventoryLootData lootData)
        {
            foreach (Slot slot in _slots)
            {
                if (slot.GetItemId() == LootId.None)
                    return true;

                if (slot.GetItemId() == lootData.LootId && !slot.IsFull())
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
            foreach (Slot emptySlot in GetEmptySlots())
            {
                if (count == 0)
                    return count;
                
                int targetCount = count > maxCountInSlot
                    ? maxCountInSlot
                    : count;
                
                count -= targetCount;
                
                emptySlot.TrySetItem(new Item(lootData.LootId, maxCountInSlot, targetCount));
            }

            return count;
        }

        /// <summary>
        /// Distributes loot to slots, which already have this type of loot.
        /// Returns remains count.
        /// </summary>
        private int DistributeToExist(InventoryLootData lootData, int count)
        {
            IEnumerable<Slot> slotsWithItem = GetSlotsWithItem(lootData.LootId);
            foreach (Slot slot in slotsWithItem)
            {
                count = slot.AddCount(count);
                if (count == 0)
                    return 0;
            }

            return count;
        }

        private IEnumerable<Slot> GetEmptySlots() 
            => _slots.Where(s => s.GetItemId() == LootId.None);

        private IEnumerable<Slot> GetSlotsWithItem(LootId lootId) 
            => _slots.Where(slot => slot.GetItemId() == lootId);
    }
}