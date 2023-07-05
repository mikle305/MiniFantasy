using System.Collections.Generic;
using Additional.Extensions;
using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.Services;
using StaticData;
using UnityEngine;

namespace GamePlay.LootSystem
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
            if (_randomizer.TryChancePercents(loot.Chance) == false)
                return;

            int lootCount = _randomizer.Generate(loot.MinCount, loot.MaxCount);
            LootPiece lootPiece = _factory.Create(loot.LootId, transform.position.AddY(1));
            lootPiece.Init(loot.LootId, lootCount);
            _lootConfigurator.Configure(lootPiece, loot.LootId);
        }
    }
}