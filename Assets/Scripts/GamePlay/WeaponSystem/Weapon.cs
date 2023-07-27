using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        private Dictionary<Type, WeaponComponent> _componentsMap;

        public void Init(WeaponComponent[] components)
        {
            foreach (WeaponComponent newComponent in components) 
                AddComponent(newComponent);
        }

        private void AddComponent(WeaponComponent newComponent)
        {
            Type componentType = newComponent.GetType();
            if (_componentsMap.ContainsKey(componentType))
                ReplaceComponent(componentType, newComponent);
            else
                SetNewComponent(componentType, newComponent);
        }

        private void SetNewComponent(Type componentType, WeaponComponent newComponent)
        {
            _componentsMap[componentType] = newComponent;
            newComponent.SetWeapon(this);
        }

        private void ReplaceComponent(Type componentType, WeaponComponent newComponent)
        {
            _componentsMap[componentType].CleanUp();
            SetNewComponent(componentType, newComponent);
        }
    }
}