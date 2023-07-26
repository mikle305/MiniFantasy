using GamePlay.LootSystem;
using UnityEngine;

namespace StaticData
{
    public abstract class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] private string _prefabPath;
        [SerializeField] private string _iconPath;
        
        [Header("Configuration")] [Space(3)]
        [SerializeField] private LootId _lootId = LootId.None;
        [SerializeField] private string _name;
        
        
        public string PrefabPath => _prefabPath;
        public string IconPath => _iconPath;
        public LootId LootId => _lootId;
        public string Name => _name;
    }
}