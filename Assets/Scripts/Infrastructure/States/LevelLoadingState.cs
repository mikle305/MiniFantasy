using CameraLogic;
using Infrastructure.Scene;
using Services.GameFactory;
using UnityEngine;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<SceneName>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LevelLoadingState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(SceneName sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            World world = _gameFactory.CreateWorld();
            GameObject character = _gameFactory.CreateCharacter(world);
            _gameFactory.CreateHud();
            FollowCamera(character.transform);
        }

        private static void FollowCamera(Transform target)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(target);
        }
    }
}