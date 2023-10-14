using GamePlay.LootSystem;
using GamePlay.WeaponSystem;

namespace Infrastructure.Services
{
    public interface IWeaponConfigurator
    {
        public void ConfigureWeaponComponents(Weapon weapon, LootId lootId);
    }
}