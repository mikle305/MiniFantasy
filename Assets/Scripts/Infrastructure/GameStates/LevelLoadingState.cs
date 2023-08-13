using GamePlay.Additional;
using GamePlay.Units.Enemy;
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
        private readonly IHudFactory _hudFactory;
        private readonly IObjectsProvider _objectsProvider;
        private readonly IProgressWatchers _progressWatchers;
        private ICharacterConfigurator _characterConfigurator;

        public LevelLoadingState(
            GameStateMachine stateMachine,
            ISceneLoader sceneLoader,
            IGameFactory gameFactory,
            IHudFactory hudFactory,
            ICharacterConfigurator characterConfigurator,
            IObjectsProvider objectsProvider,
            IProgressWatchers progressWatchers)
        {
            _characterConfigurator = characterConfigurator;
            _objectsProvider = objectsProvider;
            _hudFactory = hudFactory;
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
            GameObject character = CreateCharacter(world);
            InitEnemies(world);
            InitFollowCamera(character);
            
            Hud hud = InitHud(world, character);
            ConfigureCharacter(character);
            LoadProgress();
            BindObjectsToProvider(Camera.main, hud.Canvas);

            EnterGamePlay(character);
        }

        private World InitWorld()
        {
            World world = _gameFactory.CreateWorld();
            _progressWatchers.RegisterComponents(world, inChildren: true);
            return world;
        }

        private GameObject CreateCharacter(World world)
        {
            GameObject character = _gameFactory.CreateCharacter(world.SpawnPoint, world.transform);
            _progressWatchers.RegisterComponents(character);
            return character;
        }

        private void ConfigureCharacter(GameObject character)
            => _characterConfigurator.Configure(character);

        private Hud InitHud(World world, GameObject character) 
            => _hudFactory.CreateHud(character, world.UICamera);

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

        private void BindObjectsToProvider(
            Camera mainCamera,
            Canvas hudCanvas)
        {
            _objectsProvider.MainCamera = mainCamera;
            _objectsProvider.HudCanvas = hudCanvas;
        }

        private void EnterGamePlay(GameObject character) 
            => _stateMachine.Enter<GameProcessState, GameObject>(character);
    }
}