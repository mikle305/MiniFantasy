using GamePlay.LootSystem;
using UnityEngine;

namespace StaticData
{
    public abstract class LootData : ScriptableObject
    {
        private const string _inWorldPrefabsFolder = "Prefabs/Loot/InWorld/";
        private const string _iconsFolder = "Prefabs/Loot/Icons/";
        
        [Header("General")] [Space(3)]
        [SerializeField] private LootId _lootId = LootId.None;
        [SerializeField] private string _name;
        [SerializeField] private InWorldLootVisual _inWorldLootVisual;
        

        public string InWorldPrefabPath => _inWorldPrefabsFolder + name;
        public string IconPath => _iconsFolder + name;
        public LootId LootId => _lootId;
        public string Name => _name;
        public InWorldLootVisual InWorldLootVisual => _inWorldLootVisual;
    }
}