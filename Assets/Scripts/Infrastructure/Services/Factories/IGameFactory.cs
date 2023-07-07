using GamePlay.Additional;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameFactory
    {
        public World CreateWorld();
        
        public GameObject CreateCharacter(World world);
    }
}