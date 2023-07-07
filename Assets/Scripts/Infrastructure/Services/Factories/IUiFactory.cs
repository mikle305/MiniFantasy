using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using UI;
using UI.Inventory;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IUiFactory
    {
        public Hud CreateHud(GameObject character, Camera uiCamera);

        public SlotView CreateSlot(Slot slot, Transform slotsGrid);
        
        public ItemView CreateItem(LootId lootId, Transform itemHolder);
    }
}