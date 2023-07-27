using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public abstract class WeaponComponentData
    {
        [SerializeField] [HideInInspector] private string _name;

        public abstract Type GetComponentType();
    }
}