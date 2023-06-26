namespace Infrastructure.Services
{
    public interface IStaticDataLoader
    {
        public void LoadEnemies();

        public void LoadLoot();
    }
}