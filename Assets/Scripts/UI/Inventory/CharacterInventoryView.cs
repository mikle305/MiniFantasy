using System.Linq;
using GamePlay.InventorySystem;
using UnityEngine;

namespace UI.Inventory
{
    public class CharacterInventoryView : InventoryView
    {
        [SerializeField] private Transform _hotBarGrid;
        
        public override void ShowSlots(Slot[] slots)
        {
            foreach (Slot slot in slots.Where(s => s.IsHotSlot)) 
                _uiFactory.CreateSlot(slot, _hotBarGrid);

            Slot[] backpackSlots = slots
                .Where(s => !s.IsHotSlot)
                .ToArray();
            
            base.ShowSlots(backpackSlots);
        }
    }
}