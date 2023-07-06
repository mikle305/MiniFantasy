using GamePlay.LootSystem;

namespace GamePlay.InventorySystem
{
    public class Item
    {
        public LootId LootId { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
    }
}