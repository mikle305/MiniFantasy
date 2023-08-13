using System.Linq;
using GamePlay.InventorySystem;
using UnityEngine;

namespace UI.InventorySystem
{
    public class CharacterInventoryView : InventoryView
    {
        [SerializeField] private Transform _hotSlotsGrid;
        
        
        public override void ShowSlots(Slot[] slots)
        {
            Slot[] hotSlots = slots.Where(s => s.IsHotSlot).ToArray();
            CreateSlots(hotSlots, _hotSlotsGrid);
            
            Slot[] mainSlots = slots.Except(hotSlots).ToArray();
            base.ShowSlots(mainSlots);
        }
    }
}