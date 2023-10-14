using System;
using Additional.Utils;
using GamePlay.WeaponSystem;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public abstract class WeaponComponentData
    {
        [SerializeField] [HideInInspector] private string _name;

        private Type _componentType;


        public Type GetComponentType()
        {
            if (_componentType != null)
                return _componentType;

            Type componentType = CreateComponentType();
            ValidateComponentType(componentType);
            return _componentType ??= componentType;
        }

        private void ValidateComponentType(Type componentType)
        {
            if (!componentType.IsSubclassOf(typeof(WeaponComponent)))
                ThrowHelper.InvalidWeaponComponentType(componentType);
        }

        protected abstract Type CreateComponentType();
    }
}