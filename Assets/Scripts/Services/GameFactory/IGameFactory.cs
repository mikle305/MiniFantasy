using UnityEngine;

namespace Services.GameFactory
{
    public interface IGameFactory
    {
        public GameObject CreateCharacter(World world);
        
        public World CreateWorld();
        
        public void CreateHud();
    }
}