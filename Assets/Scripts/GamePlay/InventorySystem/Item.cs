using GamePlay.LootSystem;
using StaticData;

namespace GamePlay.InventorySystem
{
    public class Item
    {
        public InventoryLootData LootData { get; }
        public int Count { get; set; }
        public LootId LootId => LootData.LootId;
        public int MaxCount => LootData.MaxCountInSlot;


        public Item(InventoryLootData lootData, int count)
        {
            LootData = lootData;
            Count = count;
        }
    }
}