using GamePlay.LootSystem;
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.WeaponSystem
{
    /// <summary>
    /// Hand like object which can hold item
    /// </summary>
    public class ItemHolder : MonoBehaviour
    {
        private GameObject _currentItem;
        private ILootFactory _lootFactory;


        [Inject]
        public void Construct(ILootFactory lootFactory)
        {
            _lootFactory = lootFactory;
        }

        private void Start()
        {
            
        }

        private void SetActiveItem(LootId lootId)
        {
            Destroy(_currentItem);
            _currentItem = _lootFactory.CreateInHolder(lootId, this);
        }
    }
}