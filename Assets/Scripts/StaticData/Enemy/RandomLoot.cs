using System;
using GamePlay.LootSystem;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class RandomLoot
    {
        [SerializeField] private LootId _lootId;
        [SerializeField] private int _minCount = 1;
        [SerializeField] private int _maxCount = 1;
        [SerializeField] [Tooltip("In percents")]  private float _chance = 100;

        
        public LootId LootId => _lootId;
        public int MinCount => _minCount;
        public int MaxCount => _maxCount;
        public float Chance => _chance;
    }
}