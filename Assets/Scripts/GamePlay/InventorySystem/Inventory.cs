using System;
using System.Linq;
using GamePlay.LootSystem;
using StaticData;
using UnityEngine;

namespace GamePlay.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public event Action<Slot[]> SlotsAdded;
        
        public Slot[] Slots { get; private set; }


        public void Init(int slotsCount)
        {
            Slots = new Slot[slotsCount];
            for (var i = 0; i < slotsCount; i++) 
                Slots[i] = new Slot();

            SlotsAdded?.Invoke(Slots);
        }
        
        public bool CanAddLoot(InventoryLootData lootData)
        {
            foreach (Slot slot in Slots)
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
            foreach (Slot emptySlot in Slots.Where(s => s.ItemId == LootId.None))
            {
                if (count == 0)
                    return count;
                
                int countToSet = count > maxCountInSlot
                    ? maxCountInSlot
                    : count;
                
                count -= countToSet;
                
                emptySlot.TrySetItem(new Item(lootData.LootId, lootData.MaxCountInSlot, countToSet));
            }

            return count;
        }

        /// <summary>
        /// Distributes loot to slots, which already have this type of loot loot.
        /// Returns remains count.
        /// </summary>
        private int DistributeToExist(InventoryLootData lootData, int count)
        {
            foreach (Slot slot in Slots.Where(slot => slot.ItemId == lootData.LootId))
            {
                count = slot.AddCount(count);
                if (count == 0)
                    return 0;
            }

            return count;
        }
    }
}