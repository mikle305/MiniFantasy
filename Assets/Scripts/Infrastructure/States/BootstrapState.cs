using Infrastructure.Game;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.AutoSaver;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.ProgressWatchers;
using Infrastructure.Services.Storage;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private readonly GameStateMachine _stateMachine;

        private readonly SceneLoader _sceneLoader;

        private readonly ICoroutineRunner _coroutineRunner;


        public BootstrapState(
            GameStateMachine stateMachine,
            ServiceProvider services,
            SceneLoader sceneLoader,
            ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;

            RegisterServices(services);
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneName.BootstrapScene, EnterProgressLoadingState);
        }

        public void Exit()
        {
        }

        private void RegisterServices(ServiceProvider services)
        {
            IInputService inputService = CreateInputService();
            var assetProvider = new AssetProvider();
            var progressAccess = new PersistentProgressAccess();
            var progressWatchers = new ProgressWatchers(progressAccess);
            var gameFactory = new GameFactory(assetProvider, progressWatchers);
            var enemyFactory = new EnemyFactory(assetProvider);
            var storageService = new PlayerPrefsStorageService(progressAccess, progressWatchers);
            var autoSaver = new ProgressAutoSaver(storageService, _coroutineRunner);

            services.RegisterSingle<IInputService>(implementation: inputService);
            services.RegisterSingle<ICoroutineRunner>(implementation: _coroutineRunner);
            services.RegisterSingle<IAssetProvider>(implementation: assetProvider);
            services.RegisterSingle<IProgressWatchers>(implementation: progressWatchers);
            services.RegisterSingle<IEnemyFactory>(implementation: enemyFactory);
            services.RegisterSingle<IGameFactory>(implementation: gameFactory);
            services.RegisterSingle<IPersistentProgressAccess>(implementation: progressAccess);
            services.RegisterSingle<IStorageService>(implementation: storageService);
            services.RegisterSingle<IProgressAutoSaver>(implementation: autoSaver);
        }

        private static IInputService CreateInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }

        private void EnterProgressLoadingState() =>
            _stateMachine.Enter<ProgressLoadingState>();
    }
}