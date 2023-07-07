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
        private ILootConfigurator _configurator;
        private IStaticDataService _staticDataService;


        [Inject]
        public void Construct(
            ILootFactory factory, 
            ILootConfigurator configurator,
            IStaticDataService staticDataService,
            IRandomizer randomizer)
        {
            _factory = factory;
            _configurator = configurator;
            _staticDataService = staticDataService;
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

            int lootCount = _randomizer.Generate(randomLoot.MinCount, randomLoot.MaxCount);
            LootPiece lootPiece = _factory.CreateInWorld(randomLoot.LootId, transform.position.AddY(1));
            LootStaticData lootData = _staticDataService.FindLootData(randomLoot.LootId);
            lootPiece.Init(lootData, lootCount);
            _configurator.Configure(lootPiece, randomLoot.LootId);
        }
    }
}