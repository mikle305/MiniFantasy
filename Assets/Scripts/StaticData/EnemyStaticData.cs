using System;
using System.Collections.Generic;
using GamePlay.Units.Loot;
using GamePlay.Units.Spawn;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Enemy", fileName = "EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        public string PrefabPath;
        public EnemyTypeId EnemyTypeId;
        public Effect HitEffect;
        public Effect DeathEffect;

        [Header("Configuration")] [Space(3)]
        public float Health = 3;
        public float FollowingCooldown = 1;
        public float GetHitDuration = 1;
        public float DeathDuration = 2;
        public float DestroyDuration = 10;

        [Space(3)]
        public List<RandomLoot> LootCollection = new();
    }
    
    [Serializable]
    public class RandomLoot
    {
        public LootTypeId Id;
        public int MinCount = 1;
        public int MaxCount = 1;
        
        [Tooltip("In percents")] public float Chanсe = 100;
    }
}