using GamePlay.Additional;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameFactory
    {
        public World CreateWorld();

        public FollowCamera CreateFollowCamera();
        
        public GameObject CreateCharacter(Transform spawnPoint, Transform parent);
    }
}