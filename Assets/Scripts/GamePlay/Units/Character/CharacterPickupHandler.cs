using System;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using StaticData;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterPickupHandler : PickupHandler
    {
        [SerializeField] private Inventory _characterInventory;
        
        public event Action<LootData, int> Picked;

        
        public override void Handle(LootPiece lootPiece)
        {
            TryAddInInventory(lootPiece);
            TryAddCurrency(lootPiece);
        }

        private void TryAddInInventory(LootPiece lootPiece)
        {
            if (lootPiece.LootData is not InventoryLootData inventoryLootData)
                return;
                
            if (!_characterInventory.CanAddLoot(inventoryLootData))
                return;

            int beforeCount = lootPiece.CurrentCount;
            int remainsCount = _characterInventory.AddLoot(inventoryLootData, beforeCount);
            Picked?.Invoke(inventoryLootData, beforeCount - remainsCount);

            lootPiece.CurrentCount = remainsCount;
            if (remainsCount == 0) 
                lootPiece.Disappear();
        }

        private void TryAddCurrency(LootPiece lootPiece)
        {
            if (lootPiece.LootData is not CurrencyLootData currencyLootData)
                return;

            lootPiece.CurrentCount = 0;
            lootPiece.Disappear();
        }
    }
}