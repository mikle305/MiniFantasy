using System.Collections.Generic;
using System.Linq;
using GamePlay.LootSystem;
using StaticData;

namespace GamePlay.InventorySystem
{
    public class Inventory
    {
        private readonly List<Slot> _slots = new();

        public bool CanAddLoot(LootId lootId)
        {
            foreach (Slot slot in _slots)
            {
                if (slot.ItemId == LootId.None)
                    return true;

                if (slot.ItemId == lootId && !slot.IsFull())
                    return true;
            }

            return false;
        }

        public int AddLoot(LootStaticData lootId, int count)
        {
            int remainsCount = DistributeToOld(lootId, count);
            if (remainsCount == 0)
                return 0;
            
            remainsCount = DistributeToEmpty(lootId, remainsCount);
            return remainsCount;
        }

        /// <summary>
        /// Distributes loot to empty slots
        /// Returns remains count.
        /// </summary>
        private int DistributeToEmpty(LootStaticData loot, int count)
        {
            int remainsCount = count;
            Slot emptySlot = _slots.FirstOrDefault(slot => slot.ItemId == LootId.None);
            if (emptySlot != null)
            {
                emptySlot.TrySetItem(new Item
                {
                    
                });
                
            }

            return remainsCount;
        }

        /// <summary>
        /// Distributes loot to slots, which already have it.
        /// Returns remains count.
        /// </summary>
        private int DistributeToOld(LootId lootId, int count)
        {
            int remainsCount = count;
            foreach (Slot slot in _slots.Where(slot => slot.ItemId == lootId))
            {
                remainsCount = slot.AddCount(remainsCount);
                if (remainsCount == 0)
                    return 0;
            }

            return remainsCount;
        }
    }
}