using UnityEngine;
using Views;

namespace Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateCharacter(World world);
        
        public World CreateWorld();
        
        public RectTransform CreateHud();
    }
}