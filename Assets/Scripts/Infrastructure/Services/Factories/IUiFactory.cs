using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using UI;
using UI.InventorySystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IUiFactory
    {
        public Hud CreateHud(GameObject character, Camera uiCamera);

        public SlotView CreateSlot(Slot slot, Transform slotsGrid);
        
        public GameObject CreateItem(LootId lootId, Transform slot);
    }
}