using GamePlay.InventorySystem;

namespace UI.InventorySystem
{
    public class SlotActor
    {
        private readonly Slot _slot;
        private readonly SlotView _slotView;

        public SlotActor(Slot slot, SlotView slotView)
        {
            _slotView = slotView;
            _slot = slot;

            _slot.ItemChanged += _slotView.UpdateItemInfo;
        }

        public Item TakeItem(bool destroyIcon = true)
        {
            Item item = _slot.TakeItem();
            if (destroyIcon)
                _slotView.DestroyIcon();

            return item;
        }

        public void SetItem(Item item)
            => _slot.TrySetItem(item);
    }
}