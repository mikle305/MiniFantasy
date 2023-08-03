using GamePlay.InventorySystem;

namespace UI.InventorySystem
{
    public class InventoryActor
    {
        private readonly Inventory _inventory;
        private readonly InventoryView _inventoryView;

        public InventoryActor(GamePlay.InventorySystem.Inventory inventory, InventoryView inventoryView)
        {
            _inventoryView = inventoryView;
            _inventory = inventory;
        }

        public void Subscribe()
        {
            _inventory.SlotsAdded += _inventoryView.ShowSlots;
            _inventoryView.ShowSlots(_inventory.Slots);
        }
    }
}