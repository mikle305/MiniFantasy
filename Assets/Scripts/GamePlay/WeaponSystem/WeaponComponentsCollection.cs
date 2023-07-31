using System;
using System.Collections.Generic;

namespace GamePlay.WeaponSystem
{
    public class WeaponComponentsCollection
    {
        private readonly Dictionary<Type, WeaponComponent> _componentsMap;
        private readonly Weapon _weapon;


        public WeaponComponentsCollection(Weapon weapon)
        {
            _weapon = weapon;
            _componentsMap = new Dictionary<Type, WeaponComponent>();
        }

        public void AddComponents(WeaponComponent[] weaponComponents)
        {
            foreach (WeaponComponent weaponComponent in weaponComponents) 
                AddComponent(weaponComponent);
        }

        public void CleanUp()
        {
            foreach (WeaponComponent component in _componentsMap.Values) 
                component.CleanUp();
            
            _componentsMap.Clear();
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
            newComponent.InitWeapon(_weapon);
        }

        private void ReplaceComponent(Type componentType, WeaponComponent newComponent)
        {
            _componentsMap[componentType].CleanUp();
            SetNewComponent(componentType, newComponent);
        }
    }
}