namespace GamePlay.InventorySystem
{
    public class SlotActor
    {
        private Slot _slot;
        private SlotView _slotView;

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