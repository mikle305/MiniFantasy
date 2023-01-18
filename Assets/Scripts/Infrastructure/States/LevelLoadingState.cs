using CameraLogic;
using Infrastructure.Scene;
using Infrastructure.Services.Factory;
using Models;
using UnityEngine;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LevelLoadingState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
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