namespace GamePlay.InventorySystem
{
    public class InventoryActor
    {
        private Inventory _inventory;
        private InventoryView _inventoryView;

        public InventoryActor(Inventory inventory, InventoryView inventoryView)
        {
            _inventoryView = inventoryView;
            _inventory = inventory;
        }

        public void Subscribe()
        {
            _inventory.SlotsAdded += _inventoryView.AddSlots;
        }
    }
}