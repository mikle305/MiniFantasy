using Additional.Extensions;
using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.Services;
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

        public void Throw(LootId lootId, int count)
        {
            LootPiece lootPiece = _factory.Create(lootId, transform.position.AddY(1));
            lootPiece.Init(lootId, count);
            _lootConfigurator.Configure(lootPiece, lootId);
        }
    }
}