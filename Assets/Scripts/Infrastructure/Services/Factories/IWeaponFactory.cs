using System;
using GamePlay.WeaponSystem;

namespace Infrastructure.Services
{
    public interface IWeaponFactory
    {
        public Weapon CreateWeapon();
        
        public WeaponComponent CreateComponent(Type componentType);
    }
}