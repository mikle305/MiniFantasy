using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot/Weapon", fileName = "WeaponData")]
    public class WeaponData : InventoryLootData
    {
        [SerializeReference] private List<WeaponComponentData> _components;

        public Type[] GetComponentsTypes()
            => _components
                .Select(data => data.ComponentType)
                .ToArray();
    }
}