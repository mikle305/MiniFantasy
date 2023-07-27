using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.LootSystem;
using GamePlay.WeaponSystem;
using StaticData;

namespace Infrastructure.Services
{
    public class WeaponConfigurator
    {
        private readonly IStaticDataService _staticDataService;

        public WeaponConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void ConfigureWeapon(Weapon weapon, LootId lootId)
        {
            var weaponData = _staticDataService.GetLootData<WeaponData>(lootId);

            List<WeaponComponent> weaponComponents = weaponData.Components
                .Select(componentData => componentData.GetComponentType())
                .Select(componentType => _weaponFactory.CreateComponent(componentType))
                .ToList();
            
            weaponComponents.ForEach(Configure);

            weapon.Init(weaponComponents);
        }

        private void ConfigureComponent(WeaponComponent component)
            => throw new NotImplementedException();
    }
}