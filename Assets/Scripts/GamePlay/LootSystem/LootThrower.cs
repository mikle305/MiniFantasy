using Additional.Extensions;
using Infrastructure.Services;
using StaticData;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootThrower : MonoBehaviour
    {
        private ILootFactory _factory;
        private ILootConfigurator _lootConfigurator;


        [Inject]
        public void Construct(ILootFactory factory, ILootConfigurator lootConfigurator, IRandomizer randomizer)
        {
            _lootConfigurator = lootConfigurator;
            _factory = factory;
        }

        public void Throw(LootStaticData lootData, int count)
        {
            LootPiece lootPiece = _factory.CreateInWorld(lootData.LootId, transform.position.AddY(1));
            lootPiece.Init(lootData, count);
            _lootConfigurator.Configure(lootPiece, lootData.LootId);
        }
    }
}