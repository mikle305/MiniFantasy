using GamePlay.LootSystem;
using UI.Inventory;

namespace Infrastructure.Services
{
    public interface IUiConfigurator
    {
        public void ConfigureItemView(ItemView itemView, LootId lootId);
    }
}