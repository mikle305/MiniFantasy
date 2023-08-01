using System;
using Additional.Utils;
using GamePlay.LootSystem;

namespace GamePlay.InventorySystem
{
    public class Slot
    {
        private Item _currentItem;
        public event Action<LootId, int> ItemChanged;

        public LootId ItemId
            => _currentItem?.LootId ?? LootId.None;

        public bool IsHotSlot { get; }


        public Slot(bool isHotSlot = false)
        {
            IsHotSlot = isHotSlot;
        }

        public bool IsFull()
            => _currentItem.MaxCount == _currentItem.Count;

        /// <summary>
        /// Returns false
        /// if slot item is not empty
        /// or item count is zero
        /// </summary>
        public void TrySetItem(Item item)
        {
            if (_currentItem != null) 
                return;

            if (item.LootId == LootId.None)
                ThrowHelper.LootIdIsNone();

            _currentItem = item;
            InvokeItemChanged();
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

        public Item SwapItems(Item newItem)
        {
            Item oldItem = _currentItem;
            _currentItem = newItem;
            return oldItem;
        }

        private void InvokeItemChanged() 
            => ItemChanged?.Invoke(_currentItem.LootId, _currentItem.Count);
    }
}