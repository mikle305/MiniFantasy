using DiContainer.UniDependencyInjection.Core.Unity;
using Domain.Units.Animations;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace GamePlay.Loot
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private LootTypeId _lootTypeId;
        
        private ILootFactory _factory;
        private ILootConfigurator _configurator;

        
        [Inject]
        public void Construct(ILootFactory factory, ILootConfigurator configurator)
        {
            _configurator = configurator;
            _factory = factory;
        }

        private void Awake()
        {
            GetComponent<DeathOnDamage>().Happened += Spawn;
        }

        private void Spawn()
        {
            _factory.Create(_lootTypeId, transform.position, transform);
        }
    }
}