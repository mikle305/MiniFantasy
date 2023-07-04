using System;
using GamePlay.Units.Loot;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class RandomLoot
    {
        [SerializeField] private LootTypeId _id;
        [SerializeField] private int _minCount = 1;
        [SerializeField] private int _maxCount = 1;
        [SerializeField] [Tooltip("In percents")]  private float _chance = 100;

        
        public LootTypeId Id => _id;
        public int MinCount => _minCount;
        public int MaxCount => _maxCount;
        public float Chance => _chance;
    }
}