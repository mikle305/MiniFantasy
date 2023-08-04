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
        private const float _minSpawnOffset = 0.75f;
        private const float _maxSpawnOffset = 1.25f;
        private const float _ySpawnOffset = 0.7f;

        private IRandomizer _randomizer;
        private ILootFactory _factory;
        private ILootConfigurator _lootConfigurator;
        
        private List<RandomLoot> _lootCollection;


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
            if (IsLootChanceFailed(randomLoot))
                return;

            LootPiece lootPiece = CreateLootInWorld(randomLoot);
            SetLootCount(lootPiece, randomLoot);
            ConfigureLoot(lootPiece, randomLoot);
        }

        private bool IsLootChanceFailed(RandomLoot randomLoot) 
            => _randomizer.TryChancePercents(randomLoot.Chance) == false;

        private LootPiece CreateLootInWorld(RandomLoot randomLoot)
        {
            Vector3 lootPosition = 
                transform.position + new Vector3(x: GenerateRandomOffset(), y: _ySpawnOffset, z: GenerateRandomOffset());
            
            return _factory.CreateInWorld(randomLoot.LootId, lootPosition);
        }

        private void ConfigureLoot(LootPiece lootPiece, RandomLoot randomLoot) 
            => _lootConfigurator.Configure(lootPiece, randomLoot.LootId);

        private void SetLootCount(LootPiece lootPiece, RandomLoot randomLoot) 
            => lootPiece.CurrentCount = _randomizer.Generate(randomLoot.MinCount, randomLoot.MaxCount);

        private float GenerateRandomOffset() 
            => _randomizer.Generate(_minSpawnOffset, _maxSpawnOffset) * _randomizer.GenerateSign();
    }
}