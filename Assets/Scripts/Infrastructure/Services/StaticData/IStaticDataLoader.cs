namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataLoader
    {
        public void LoadEnemies();

        public void LoadLoot();
    }
}