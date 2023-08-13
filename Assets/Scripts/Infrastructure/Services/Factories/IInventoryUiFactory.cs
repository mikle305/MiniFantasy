using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using UI.InventorySystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IInventoryUiFactory
    {
        public SlotView CreateSlot(Slot slot, Transform slotsGrid);
        
        public GameObject CreateItem(LootId lootId, SlotView slotView);
    }
}