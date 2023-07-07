using GamePlay.InventorySystem;

namespace UI.Inventory
{
    public class SlotActor
    {
        private readonly Slot _slot;
        private readonly SlotView _slotView;

        public SlotActor(Slot slot, SlotView slotView)
        {
            _slotView = slotView;
            _slot = slot;
        }

        public void Subscribe()
        {
            _slot.ItemChanged += _slotView.UpdateItemInfo;
        }
    }
}