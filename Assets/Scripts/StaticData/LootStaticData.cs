using GamePlay.Units.Loot;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot", fileName = "LootData")]
    public class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)]
        [SerializeField] private LootTypeId _lootTypeId;
        [SerializeField] private string _prefabPath;
        
        
        public LootTypeId TypeId => _lootTypeId;
        public string PrefabPath => _prefabPath;
    }
}