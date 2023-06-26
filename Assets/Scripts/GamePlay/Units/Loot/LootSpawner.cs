using System.Collections.Generic;
using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.Services;
using StaticData;
using UnityEngine;

namespace GamePlay.Units.Loot
{
    public class LootSpawner : MonoBehaviour
    {
        private ILootFactory _factory;
        private List<RandomLoot> _lootCollection;
        private IRandomizer _randomizer;
        private ILootConfigurator _lootConfigurator;


        [Inject]
        public void Construct(ILootFactory factory, ILootConfigurator lootConfigurator, IRandomizer randomizer)
        {
            _lootConfigurator = lootConfigurator;
            _randomizer = randomizer;
            _factory = factory;
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

        private void SpawnOne(RandomLoot loot)
        {
            if (_randomizer.TryChancePercents(loot.Chanсe) == false)
                return;

            int lootCount = _randomizer.Generate(loot.MinCount, loot.MaxCount);
            LootPiece lootPiece = _factory.Create(loot.Id, transform.position, transform);
            lootPiece.Init(lootCount);
            _lootConfigurator.Configure(lootPiece, loot.Id);
        }
    }
}