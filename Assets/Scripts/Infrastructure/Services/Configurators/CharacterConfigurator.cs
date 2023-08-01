using GamePlay.InventorySystem;
using GamePlay.Units;
using GamePlay.Units.Death;
using GamePlay.Units.Hit;
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
            CharacterData data = _staticDataService.GetCharacterData();
            InitHealth(character, data);
            InitDeath(character, data);
            InitHitting(character, data);
            InitInventory(character, data);
        }

        private static void InitInventory(GameObject character, CharacterData data)
        {
            if (!character.TryGetComponent(out Inventory inventory))
                return;

            var slots = new Slot[data.BackpackSlots + data.HotBarSlots];
            for (var i = 0; i < data.BackpackSlots; i++)
                slots[i] = new Slot();
            
            for (int i = data.BackpackSlots; i < slots.Length; i++)
                slots[i] = new Slot(isHotSlot: true);

            inventory.Init(slots);
        }

        private static void InitHealth(GameObject character, CharacterData data)
        {
            if (character.TryGetComponent(out Health health))
                health.Init(data.Health, data.Health);
        }

        private static void InitDeath(GameObject character, CharacterData data)
        {
            if (character.TryGetComponent(out Death deathOnDamage))
                deathOnDamage.Init(data.DeathDuration);
            
            if (character.TryGetComponent(out DestroyOnDeath destroyOnDeath))
                destroyOnDeath.Init(data.DestroyDuration);
            
            if (character.TryGetComponent(out EffectOnDeath effectOnDeath))
                effectOnDeath.Init(data.DeathEffect);
        }

        private static void InitHitting(GameObject character, CharacterData data)
        {
            if (character.TryGetComponent(out HitOnDamage hitOnDamage))
                hitOnDamage.Init(data.GetHitDuration);

            if (character.TryGetComponent(out EffectOnHit effectOnHit))
                effectOnHit.Init(data.HitEffect);
        }
    }
}