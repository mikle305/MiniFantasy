using System;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units
{
    public class CharacterPickupHandler : PickupHandler
    {
        [SerializeField] private Inventory _inventory;
        
        private IStaticDataAccess _staticDataAccess;
        public event Action<LootId, int> Picked;
        
        
        public override void Handle(LootPiece lootPiece)
        {
            int lootCount = lootPiece.PickUpAll();
            LootId lootId = lootPiece.LootId;
            _inventory.AddLoot(lootId, lootCount);
            Picked?.Invoke(lootId, lootCount);
        }
    }
}