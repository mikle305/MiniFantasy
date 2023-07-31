using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Weapon", fileName = "WeaponData")]
    public class WeaponData : InventoryLootData
    {
        [Space(5)] [Header("Weapon")] [Space(3)]
        [SerializeReference] private List<WeaponComponentData> _componentsData;
        
        public List<WeaponComponentData> ComponentsData => _componentsData;
    }
}