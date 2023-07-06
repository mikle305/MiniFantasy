using System;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units
{
    public class CharacterPickupHandler : PickupHandler
    {
        [SerializeField] private LootThrower _lootThrower;
        
        private IStaticDataAccess _staticDataAccess;
        public event Action<LootId, int> Picked;
        
        
        public override void Handle(LootPiece lootPiece)
        {
            int lootCount = lootPiece.PickUpAll();
            LootId lootId = lootPiece.LootId;
            if (!_inventory.CanAddLoot(lootId))
                return;
            
            lootPiece.Disappear();
            int remainsCount = _inventory.AddLoot(lootId, lootCount);
            if (remainsCount > 0)
                _lootThrower.Throw(lootId, remainsCount);
            
            Picked?.Invoke(lootId, lootCount);
        }
    }
}