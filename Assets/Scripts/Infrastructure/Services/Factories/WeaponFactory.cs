using System;
using Additional.Utils;
using GamePlay.LootSystem;
using GamePlay.WeaponSystem;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;


        public WeaponFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        
        public Weapon CreateWeapon(LootId lootId)
        {
            var weaponData = _staticDataService.GetLootData<WeaponData>(lootId);
            _assetProvider.Instantiate<Weapon>(weaponData.WeaponPrefabPath);
        }

        public WeaponComponent CreateComponents(LootId lootId)
        {
            var weaponData = _staticDataService.GetLootData<WeaponData>(lootId);
            if (componentType.IsSubclassOf(typeof(WeaponComponent)))
                ThrowHelper.InvalidWeaponComponentType(componentType);

            return Activator.CreateInstance(componentType) as WeaponComponent;
        }
    }
}