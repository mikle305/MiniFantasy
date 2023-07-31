using Additional.Extensions;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using StaticData;
using TMPro;
using UnityEngine;

namespace UI.Inventory
{
    public class ItemView : MonoBehaviour
    {
        private HudConfiguration _hudConfig;
        private TextMeshProUGUI _nameText;
        private TextMeshProUGUI _countText;

        public LootId LootId { get; set; }
        
        
        public void InitData(HudConfiguration hudConfig)
        {
            _hudConfig = hudConfig;
        }

        public void InitComponents(TextMeshProUGUI nameText, TextMeshProUGUI countText)
        {
            _countText = countText;
            _nameText = nameText;
        }

        public void ShowName(string itemName) 
            => _nameText.text = itemName.SplitByCapital().ConvertToString(" ");

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