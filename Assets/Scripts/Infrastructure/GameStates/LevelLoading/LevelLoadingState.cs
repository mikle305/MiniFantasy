using Additional.Abstractions.States;
using Domain.Camera;
using Domain.Units.Spawn;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.Scene;
using UnityEngine;
using Views;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IProgressWatchers _progressWatchers;

        public LevelLoadingState(
            GameStateMachine stateMachine,
            ISceneLoader sceneLoader,
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
            InitEnemies(world);
            
            GameObject character = InitCharacter(world);
            _progressWatchers.InformReaders();
            InitHud(character);
            FollowCamera(character);
            
            EnterGamePlay(character);
        }

        private World InitWorld() 
            => _gameFactory.CreateWorld();

        private GameObject InitCharacter(World world) 
            => _gameFactory.CreateCharacter(world);

        private Hud InitHud(GameObject character) 
            => _gameFactory.CreateHud(character);

        private static GameObject[] InitEnemies(World world)
        {
            EnemySpawner[] spawners = world.EnemySpawners;
            var enemies = new GameObject[spawners.Length];
            
            for (var i = 0; i < spawners.Length; i++) 
                enemies[i] = spawners[i].Spawn();

            return enemies;
        }

        private static void BakeNavMesh(World world) 
            => world.NavMeshBaker.Bake();

        private static void FollowCamera(GameObject target) =>
            Camera.main!
                .GetComponent<CameraFollow>()
                .Follow(target.transform);

        private void EnterGamePlay(GameObject character) 
            => _stateMachine.Enter<GameProcessState, GameObject>(character);
    }
}