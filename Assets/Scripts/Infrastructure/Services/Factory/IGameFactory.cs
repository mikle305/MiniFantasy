using UnityEngine;
using Views;

namespace Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        public World CreateWorld();
        
        public GameObject CreateCharacter(World world);
        
        public Hud CreateHud(GameObject character);
    }
}