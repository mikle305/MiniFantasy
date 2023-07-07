using GamePlay.LootSystem;

namespace GamePlay.InventorySystem
{
    public class Item
    {
        public int Count { get; set; }
        public LootId LootId { get; }
        public int MaxCount { get; }


        public Item(LootId lootId, int maxCount, int count)
        {
            LootId = lootId;
            MaxCount = maxCount;
            Count = count;
        }
    }
}