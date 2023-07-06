using Additional.Utils;
using GamePlay.LootSystem;

namespace GamePlay.InventorySystem
{
    public class Slot
    {
        private Item _currentItem;
        
        public LootId ItemId 
            => _currentItem?.LootId 
               ?? LootId.None;

        public bool IsFull()
            => _currentItem.MaxCount == _currentItem.Count;

        
        /// <summary>
        /// Returns false if slot item is not empty
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TrySetItem(Item item)
        {
            if (_currentItem != null) 
                return false;

            if (item.LootId == LootId.None)
                ThrowHelper.LootIdIsNone();
            
            _currentItem = item;
            return true;
        }

        public Item ChangeItem(Item newItem)
        {
            Item oldItem = _currentItem;
            _currentItem = newItem;
            return oldItem;
        }

        /// <summary>
        /// Adds count to current item
        /// Returns extra count
        /// </summary>
        public int AddCount(int count)
        {
            if (count == 0)
                return 0;
            
            int canApplyCount = _currentItem.MaxCount - _currentItem.Count;
            if (count > canApplyCount)
            {
                _currentItem.Count += canApplyCount;
                return count - canApplyCount;
            }

            _currentItem.Count += count;
            return 0;
        }
    }
}