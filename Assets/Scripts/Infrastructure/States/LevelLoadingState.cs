using Additional.Abstractions.States;
using Domain.Camera;
using Domain.Units.Spawn;
using Infrastructure.Game;
using Infrastructure.Scene;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Progress;
using UnityEngine;
using Views;

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
            
            _sceneLoader.Load(sceneName, onLoaded: InitGameWorld);
        }

        public void Exit()
        {
        }

        private void InitGameWorld()
        {
            World world = InitWorld();
            BakeNavMesh(world);
            InitEnemies(world);
            
            GameObject character = InitCharacter(world);
            InitHud(character);
            FollowCamera(character);
            
            EnterGamePlay(character);
        }

        private void EnterGamePlay(GameObject character)
        {
            _stateMachine.Enter<GamePlayState, GameObject>(character);
        }

        private static void BakeNavMesh(World world)
        {
            world.NavMeshBaker.Bake();
        }

        private Hud InitHud(GameObject character)
        {
            return _gameFactory.CreateHud(character);
        }

        private World InitWorld() 
            => _gameFactory.CreateWorld();

        private GameObject InitCharacter(World world)
        {
            GameObject character =_gameFactory.CreateCharacter(world);
            _progressWatchers.InformReaders();
            return character;
        }

        private GameObject[] InitEnemies(World world)
        {
            EnemySpawner[] spawners = world.EnemySpawners;
            var enemies = new GameObject[spawners.Length];
            
            for (var i = 0; i < spawners.Length; i++) 
                enemies[i] = spawners[i].Spawn();

            return enemies;
        }

        private static void FollowCamera(GameObject target)
        {
            Camera.main!
                .GetComponent<CameraFollow>()
                .Follow(target.transform);
        }
    }
}