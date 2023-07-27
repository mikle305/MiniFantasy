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


        [Inject]
        public void Construct(ILootFactory factory, IRandomizer randomizer)
        {
            _factory = factory;
        }

        public void Throw(LootData lootData, int count)
        {
            LootPiece lootPiece = _factory.CreateInWorld(lootData.LootId, transform.position.AddY(1));
            lootPiece.Init(lootData, count);
        }
    }
}