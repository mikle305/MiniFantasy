using Domain.Units.Spawn;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Enemy", fileName = "EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        public string PrefabPath;
        public Effect HitEffect;
        public Effect DeathEffect;

        [Header("Configuration")] [Space(3)] 
        public EnemyTypeId EnemyTypeId;
        public float Health;
        public float FollowingCooldown;
        public float HitDuration;
        public float DeathDuration;
        public float DestroyDuration;
    }
}