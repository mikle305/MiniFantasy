using StaticData;
using TMPro;
using UnityEngine;

namespace GamePlay.InventorySystem
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _countText;
        
        private SlotActor _slotActor;

        
        public void Init(Slot slot)
        {
            _slotActor = new SlotActor(slot, this);
            _slotActor.Subscribe();
        }

        public void UpdateItemInfo(InventoryLootData lootData, int count)
        {
            _nameText.text = lootData.Name;
            _countText.text = count.ToString();
        }
    }
}