using Domain.Camera;
using Infrastructure.Scene;
using Infrastructure.Services.Factory;
using Infrastructure.Services.ProgressWatchers;
using Models;
using UnityEngine;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IProgressWatchers _progressWatchers;

        public LevelLoadingState(
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            IGameFactory gameFactory,
            IProgressWatchers progressWatchers)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressWatchers = progressWatchers;
        }

        public void Enter(string sceneName)
        {
            _progressWatchers.CleanUp();
            _sceneLoader.Load(sceneName, () =>
            {
                InitGameWorld();
                _progressWatchers.InformReaders();
            });
        }

        public void Exit()
        {
        }

        private void InitGameWorld()
        {
            World world = _gameFactory.CreateWorld();
            GameObject character = _gameFactory.CreateCharacter(world);
            _gameFactory.CreateHud();
            
            FollowCamera(character.transform);
            
            world.NavMeshBaker.Bake();
        }

        private static void FollowCamera(Transform target)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(target);
        }
    }
}