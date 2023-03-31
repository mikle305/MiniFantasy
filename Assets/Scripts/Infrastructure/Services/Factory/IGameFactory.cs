using UnityEngine;
using Views;

namespace Infrastructure.Services
{
    public interface IGameFactory
    {
        public World CreateWorld();
        
        public GameObject CreateCharacter(World world);
        
        public Hud CreateHud(GameObject character);
    }
}