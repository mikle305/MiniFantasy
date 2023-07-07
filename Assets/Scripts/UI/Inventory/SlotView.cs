using GamePlay.InventorySystem;
using Infrastructure.Services;
using StaticData;
using TMPro;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.Inventory
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _countText;
        
        private SlotActor _slotActor;
        private IConfigAccess _configAccess;
        private HudConfiguration _hudConfig;


        [Inject]
        public void Construct(IConfigAccess configAccess)
        {
            _configAccess = configAccess;
        }
        
        public void Init(Slot slot)
        {
            _slotActor = new SlotActor(slot, this);
            _slotActor.Subscribe();

            _hudConfig = _configAccess.FindHudConfig();
        }

        public void UpdateItemInfo(InventoryLootData lootData, int count)
        {
            _countText.text = count.ToString();

            if (!_hudConfig.ItemRarityColorMap.TryGetValue(lootData.ItemRarity, out Color rarityColor))
                rarityColor = Color.white;

            _nameText.color = (Color32) rarityColor;
            _nameText.text = lootData.Name;
        }
    }
}