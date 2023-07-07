namespace UI.Inventory
{
    public class InventoryActor
    {
        private GamePlay.InventorySystem.Inventory _inventory;
        private InventoryView _inventoryView;

        public InventoryActor(GamePlay.InventorySystem.Inventory inventory, InventoryView inventoryView)
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