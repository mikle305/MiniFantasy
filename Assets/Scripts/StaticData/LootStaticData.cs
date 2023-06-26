using GamePlay.Units.Loot;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot", fileName = "LootData")]
    public class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)] 
        public string PrefabPath;
        public LootTypeId LootTypeId;
    }
}