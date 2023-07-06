using System.Collections.Generic;
using GamePlay.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Enemy", fileName = "EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] [FormerlySerializedAs("EnemyTypeId")] private EnemyId _enemyId = EnemyId.None;
        [SerializeField] [FormerlySerializedAs("PrefabPath")] private string _prefabPath;
        [SerializeField] [FormerlySerializedAs("HitEffect")] private Effect _hitEffect;
        [SerializeField] [FormerlySerializedAs("DeathEffect")] private Effect _deathEffect;

        [Header("Configuration")] [Space(3)]
        [SerializeField] [FormerlySerializedAs("Health")] private float _health = 3;
        [SerializeField] [FormerlySerializedAs("FollowingCooldown")] private float _followingCooldown = 1;
        [SerializeField] [FormerlySerializedAs("GetHitDuration")] private float _getHitDuration = 1;
        [SerializeField] [FormerlySerializedAs("DeathDuration")] private float _deathDuration = 2;
        [SerializeField] [FormerlySerializedAs("DestroyDuration")] private float _destroyDuration = 10;
        
        [Space(3)]
        [SerializeField] private List<RandomLoot> _lootCollection = new();

        
        public string PrefabPath => _prefabPath;
        public EnemyId Id => _enemyId;
        public Effect HitEffect => _hitEffect;
        public Effect DeathEffect => _deathEffect;
        public float Health => _health;
        public float FollowingCooldown => _followingCooldown;
        public float DeathDuration => _deathDuration;
        public float GetHitDuration => _getHitDuration;
        public float DestroyDuration => _destroyDuration;
        public List<RandomLoot> LootCollection => _lootCollection;
    }
}