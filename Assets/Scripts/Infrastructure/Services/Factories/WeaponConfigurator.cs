using System;
using System.Linq;
using GamePlay.LootSystem;
using GamePlay.WeaponSystem;
using StaticData;

namespace Infrastructure.Services
{
    public class WeaponConfigurator : IWeaponConfigurator
    {
        private readonly IStaticDataService _staticDataService;


        public WeaponConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void ConfigureWeaponComponents(Weapon weapon, LootId lootId)
        {
            WeaponComponent[] weaponComponents = _staticDataService
                .GetLootData<WeaponData>(lootId)
                .ComponentsData
                .Select(CreateComponent)
                .ToArray();

            WeaponComponentsCollection componentsCollection = weapon.ComponentsCollection;
            componentsCollection.CleanUp();
            componentsCollection.AddComponents(weaponComponents);
        }

        private static WeaponComponent CreateComponent(WeaponComponentData componentData)
        {
            var component = Activator.CreateInstance(componentData.GetComponentType()) as WeaponComponent;
            component!.InitData(componentData);
            return component;
        }
    }
}