using System;
using Additional.Utils;
using GamePlay.LootSystem;

namespace GamePlay.InventorySystem
{
    public class Slot
    {
        private Item _currentItem;
        public event Action<LootId, int> ItemChanged;

        public bool IsHotSlot { get; }


        public Slot(bool isHotSlot = false)
        {
            IsHotSlot = isHotSlot;
        }

        public LootId GetItemId() 
            => _currentItem?.LootId ?? LootId.None;

        public bool IsFull()
            => _currentItem.MaxCount == _currentItem.Count;

        public void TrySetItem(Item item)
        {
            if (GetItemId() != LootId.None) 
                return;

            _currentItem = item;
            InvokeItemChanged();
        }

        public Item TakeItem()
        {
            Item item = _currentItem;
            _currentItem = null;
            InvokeItemChanged();
            return item;
        }

        /// <summary>
        /// Adds count to current item
        /// Returns extra count
        /// </summary>
        public int AddCount(int count)
        {
            if (count == 0)
                return count;

            if (IsFull())
                return count;
            
            int canApplyCount = _currentItem.MaxCount - _currentItem.Count;
            if (count > canApplyCount)
            {
                _currentItem.Count += canApplyCount;
                InvokeItemChanged();
                return count - canApplyCount;
            }

            _currentItem.Count += count;
            InvokeItemChanged();
            return 0;
        }

        private void InvokeItemChanged() 
            => ItemChanged?.Invoke(GetItemId(), GetItemCount());

        private int GetItemCount() 
            => _currentItem?.Count ?? 0;
    }
}