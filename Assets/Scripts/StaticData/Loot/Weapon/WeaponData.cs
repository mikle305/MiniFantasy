using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Weapon", fileName = "WeaponData")]
    public class WeaponData : InventoryLootData
    {
        [SerializeField] private string _weaponPrefabPath;
        [SerializeReference] private List<WeaponComponentData> _components;

        public List<WeaponComponentData> Components => _components;

        public string WeaponPrefabPath => _weaponPrefabPath;
    }
}