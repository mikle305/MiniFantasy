using Domain.Units.Spawn;
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
    }
}