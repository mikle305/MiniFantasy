using CameraLogic;
using Infrastructure.Scene;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Models;
using UnityEngine;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LevelLoadingState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
        }

        private void InitGameWorld()
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

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.PlayerProgress);
            }   
        }
    }
}