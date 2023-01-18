using Infrastructure.Services;
using Models;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateCharacter(World world);
        
        public World CreateWorld();
        
        public void CreateHud();
    }
}