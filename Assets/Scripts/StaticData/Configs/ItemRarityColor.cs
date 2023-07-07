using System;
using GamePlay.InventorySystem;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class ItemRarityColor
    {
        [SerializeField] private ItemRarity _rarity;
        [SerializeField] private Color _color;
        
        public ItemRarity Rarity => _rarity;
        public Color Color => _color;
    }
}