using GamePlay.InventorySystem;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IUiFactory
    {
        public Hud CreateHud(GameObject character, Camera uiCamera);

        public SlotView CreateSlot(Slot slot, Transform slotsGrid);
    }
}