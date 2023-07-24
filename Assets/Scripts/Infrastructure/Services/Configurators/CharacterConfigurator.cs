using GamePlay.InventorySystem;
using GamePlay.Units;
using StaticData.Character;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CharacterConfigurator : ICharacterConfigurator
    {
        private readonly IStaticDataService _staticDataService;
        

        public CharacterConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Configure(GameObject character)
        {
            CharacterStaticData data = _staticDataService.GetCharacterData();
            InitHealth(character, data);
            InitDeath(character, data);
            InitHitting(character, data);
            InitInventory(character, data);
        }

        private static void InitInventory(GameObject character, CharacterStaticData data)
        {
            if (character.TryGetComponent(out Inventory inventory))
                inventory.Init(data.InventorySlots);
        }

        private static void InitHealth(GameObject character, CharacterStaticData data)
        {
            if (character.TryGetComponent(out Health health))
                health.Init(data.Health, data.Health);
        }

        private static void InitDeath(GameObject character, CharacterStaticData data)
        {
            if (character.TryGetComponent(out Death deathOnDamage))
                deathOnDamage.Init(data.DeathDuration);
            
            if (character.TryGetComponent(out DestroyOnDeath destroyOnDeath))
                destroyOnDeath.Init(data.DestroyDuration);
            
            if (character.TryGetComponent(out EffectOnDeath effectOnDeath))
                effectOnDeath.Init(data.DeathEffect);
        }

        private static void InitHitting(GameObject character, CharacterStaticData data)
        {
            if (character.TryGetComponent(out HitOnDamage hitOnDamage))
                hitOnDamage.Init(data.GetHitDuration);

            if (character.TryGetComponent(out EffectOnHit effectOnHit))
                effectOnHit.Init(data.HitEffect);
        }
    }
}