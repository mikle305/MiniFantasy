using CameraLogic;
using Character;
using Infrastructure.Scene;
using UnityEngine;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<SceneName>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        
        public LevelLoadingState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(SceneName sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private static void OnLoaded()
        {
            World world = CreateWorld();
            GameObject character = CreateCharacter(world);
            CreateHud();
            FollowCamera(character.transform);
        }

        private static World CreateWorld()
        {
            var prefab = Resources.Load<World>("World/World");
            return Object.Instantiate(prefab);
        }

        private static GameObject CreateCharacter(World world)
        {
            var prefab = Resources.Load<GameObject>("Characters/Prefabs/Character");
            GameObject character = Object.Instantiate(prefab, world.SpawnPoint.position, Quaternion.identity, world.transform);
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            return character;
        }

        private static void CreateHud()
        {
            var prefab = Resources.Load<GameObject>("UI/Hud");
            Object.Instantiate(prefab);
        }

        private static void FollowCamera(Transform target)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(target);
        }
    }
}