using Character;
using UnityEngine;

namespace Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private const string _worldResourcePath = "World/World";
        private const string _characterResourcePath = "Characters/Prefabs/Character";
        private const string _hudResourcePath = "UI/Hud";
        
        public GameObject CreateCharacter(World world)
        {
            GameObject character = Instantiate(_characterResourcePath, world.SpawnPoint.position, world.transform);
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            return character;
        }

        public World CreateWorld()
        {
            return Instantiate<World>(_worldResourcePath);
        }

        public void CreateHud()
        {
            Instantiate(_hudResourcePath);
        }

        private static GameObject Instantiate(string path, Vector3? position = null, Transform parent = null)
        {
            return Instantiate<GameObject>(path, position, parent);
        }
        
        private static T Instantiate<T>(string path, Vector3? position = null, Transform parent = null) where T: Object
        {
            var prefab = Resources.Load<T>(path);
            
            if (position == null && parent != null)
                return Object.Instantiate(prefab, parent);
            
            if (position != null && parent == null)
                return Object.Instantiate(prefab, (Vector3)position, Quaternion.identity);
            
            if (position != null && parent != null)
                return Object.Instantiate(prefab, (Vector3)position, Quaternion.identity, parent);
            
            return Object.Instantiate(prefab);
        }
    }
}