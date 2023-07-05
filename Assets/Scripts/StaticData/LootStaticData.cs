using GamePlay.LootSystem;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot", fileName = "LootData")]
    public class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] private LootId _lootId = LootId.None;
        [SerializeField] private string _prefabPath;
        
        
        public LootId LootId => _lootId;
        public string PrefabPath => _prefabPath;
    }
}