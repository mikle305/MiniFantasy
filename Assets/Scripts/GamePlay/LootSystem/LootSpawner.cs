using System.Collections.Generic;
using Additional.Extensions;
using Infrastructure.Services;
using StaticData;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootSpawner : MonoBehaviour
    {
        private List<RandomLoot> _lootCollection;
        private IRandomizer _randomizer;
        private ILootFactory _factory;
        private ILootConfigurator _lootConfigurator;
        private LootId _lootId;


        [Inject]
        public void Construct(
            ILootFactory factory,
            ILootConfigurator lootConfigurator,
            IRandomizer randomizer)
        {
            _lootConfigurator = lootConfigurator;
            _factory = factory;
            _randomizer = randomizer;
        }

        public void Init(List<RandomLoot> lootCollection)
        {
            _lootCollection = lootCollection;
        }

        public void Spawn()
        {
            foreach (RandomLoot loot in _lootCollection) 
                SpawnOne(loot);
        }

        private void SpawnOne(RandomLoot randomLoot)
        {
            if (_randomizer.TryChancePercents(randomLoot.Chance) == false)
                return;

            _lootId = randomLoot.LootId;
            LootPiece lootPiece = _factory.CreateInWorld(_lootId, transform.position.AddY(1));
            _lootConfigurator.Configure(lootPiece, _lootId);
            lootPiece.CurrentCount = GenerateLootCount(randomLoot);
        }

        private int GenerateLootCount(RandomLoot randomLoot) 
            => _randomizer.Generate(randomLoot.MinCount, randomLoot.MaxCount);
    }
}