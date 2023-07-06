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
        private List<RandomLoot> _lootCollection;
        private IRandomizer _randomizer;
        private ILootFactory _factory;
        private ILootConfigurator _configurator;
        private IStaticDataAccess _staticDataAccess;


        [Inject]
        public void Construct(
            ILootFactory factory, 
            ILootConfigurator configurator,
            IStaticDataAccess staticDataAccess,
            IRandomizer randomizer)
        {
            _factory = factory;
            _configurator = configurator;
            _staticDataAccess = staticDataAccess;
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

        private void SpawnOne(RandomLoot loot)
        {
            if (_randomizer.TryChancePercents(loot.Chance) == false)
                return;

            int lootCount = _randomizer.Generate(loot.MinCount, loot.MaxCount);
            LootPiece lootPiece = _factory.Create(loot.LootId, transform.position.AddY(1));
            _configurator.Configure(lootPiece, loot.LootId);
            lootPiece.Init(loot.LootId, lootCount);
        }
    }
}