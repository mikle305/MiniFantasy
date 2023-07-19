using GamePlay.Additional;
using GamePlay.Units;
using Infrastructure.Services;
using UI;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class LevelLoadingState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUiFactory _uiFactory;
        private readonly IObjectsProvider _objectsProvider;
        private readonly IProgressWatchers _progressWatchers;

        public LevelLoadingState(
            GameStateMachine stateMachine,
            ISceneLoader sceneLoader,
            IGameFactory gameFactory,
            IUiFactory uiFactory,
            IObjectsProvider objectsProvider,
            IProgressWatchers progressWatchers)
        {
            _objectsProvider = objectsProvider;
            _uiFactory = uiFactory;
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
            GameObject character = InitCharacter(world);
            InitEnemies(world);
            LoadProgress();
            InitHud(world, character);
            InitFollowCamera(character);
            BindObjectsToProvider();
            EnterGamePlay(character);
        }

        private void BindObjectsToProvider()
        {
            _objectsProvider.MainCamera = Camera.main;
        }

        private World InitWorld() 
            => _gameFactory.CreateWorld();

        private GameObject InitCharacter(World world) 
            => _gameFactory.CreateCharacter(world);

        private Hud InitHud(World world, GameObject character) 
            => _uiFactory.CreateHud(character, world.UICamera);

        private void LoadProgress() 
            => _progressWatchers.InformReaders();

        private static GameObject[] InitEnemies(World world)
        {
            EnemySpawner[] spawners = world.EnemySpawners;
            var enemies = new GameObject[spawners.Length];
            
            for (var i = 0; i < spawners.Length; i++) 
                enemies[i] = spawners[i].Spawn();

            return enemies;
        }

        private void InitFollowCamera(GameObject target) 
            => _gameFactory
                .CreateFollowCamera()
                .Follow(target.transform);

        private void EnterGamePlay(GameObject character) 
            => _stateMachine.Enter<GameProcessState, GameObject>(character);
    }
}