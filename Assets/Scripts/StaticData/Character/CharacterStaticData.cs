using UnityEngine;

namespace StaticData.Character
{
    [CreateAssetMenu(menuName = "StaticData/Character", fileName = "CharacterData")]
    public class CharacterStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] private string _prefabPath;
        [SerializeField] private Effect _hitEffect;
        [SerializeField] private Effect _deathEffect;

        [Header("Configuration")] [Space(3)]
        [SerializeField] private float _health;
        [SerializeField] private float _getHitDuration;
        [SerializeField] private float _deathDuration;
        [SerializeField] private float _destroyDuration;
        [SerializeField] private int _inventorySlots = 24;
        
        
        public string PrefabPath => _prefabPath;

        public Effect HitEffect => _hitEffect;
        
        public Effect DeathEffect => _deathEffect;

        public float Health => _health;

        public float GetHitDuration => _getHitDuration;
        
        public float DeathDuration => _deathDuration;
        
        public float DestroyDuration => _destroyDuration;

        public int InventorySlots => _inventorySlots;
    }
}