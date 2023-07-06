using GamePlay.LootSystem;
using UnityEngine;

namespace StaticData
{
    public abstract class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] private string _prefabPath;
        [SerializeField] private Sprite _icon;
        
        [Header("Configuration")] [Space(3)]
        [SerializeField] private LootId _lootId = LootId.None;

        public string PrefabPath => _prefabPath;
        public Sprite Icon => _icon;
        public LootId LootId => _lootId;
    }
}