using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class LootStaticData : ScriptableObject
    {
        [Header("Resources")] [Space(3)] 
        public string PrefabPath;
        public LootTypeId LootTypeId;
    }
}