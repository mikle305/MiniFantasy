using System.Collections.Generic;
using System.Linq;
using GamePlay.InventorySystem;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/HudConfiguration", fileName = "HudConfiguration")]
    public class HudConfiguration : ScriptableObject
    {
        [SerializeField] private List<ItemRarityColor> _itemRarityColors;

        private Dictionary<ItemRarity, Color> _itemRarityColorMap;

        public Dictionary<ItemRarity, Color> ItemRarityColorMap => _itemRarityColorMap 
            ??= _itemRarityColors.ToDictionary(i => i.Rarity, i => i.Color);
    }
}