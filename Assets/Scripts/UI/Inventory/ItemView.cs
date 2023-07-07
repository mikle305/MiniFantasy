using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using Infrastructure.Services;
using StaticData;
using TMPro;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.Inventory
{
    public class ItemView : MonoBehaviour
    {
        private HudConfiguration _hudConfig;
        private TextMeshProUGUI _nameText;
        private TextMeshProUGUI _countText;

        public LootId LootId { get; set; }
        

        [Inject]
        public void Construct(IConfigAccess configAccess)
        {
            _hudConfig = configAccess.FindHudConfig();
        }

        public void Init(TextMeshProUGUI nameText, TextMeshProUGUI countText)
        {
            _countText = countText;
            _nameText = nameText;
        }

        public void ShowName(string itemName) 
            => _nameText.text = itemName;

        public void ShowCount(int itemCount)
        {
            _countText.text = itemCount.ToString();
        }

        public void ShowRarity(ItemRarity itemRarity)
        {
            if (!_hudConfig.ItemRarityColorMap.TryGetValue(itemRarity, out Color rarityColor))
                rarityColor = Color.white;

            _nameText.color = rarityColor;
        }
    }
}