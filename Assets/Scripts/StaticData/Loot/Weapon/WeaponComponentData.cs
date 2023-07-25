using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public abstract class WeaponComponentData
    {
        [SerializeField] [HideInInspector] private string _name;


        protected WeaponComponentData()
        {
            SetComponentType();
        }
        
        public Type ComponentType { get; protected set; }

        protected abstract void SetComponentType();
    }
}