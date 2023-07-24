using GamePlay.Additional;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameFactory
    {
        public World CreateWorld();

        public GameObject CreateCharacter(Vector3 position, Transform parent);
        
        public FollowCamera CreateFollowCamera();
    }
}