using Additional.Abstractions.States;
using Infrastructure.Game;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.AutoSaver;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Fps;
using Infrastructure.Services.Input;
using Infrastructure.Services.Progress;
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
            _sceneLoader.Load(
                SceneName.BootstrapScene, 
                onLoaded: () => _stateMachine.Enter<ProgressLoadingState>());
        }

        public void Exit()
        {
        }

        private void RegisterServices(ServiceProvider services)
        {
            services.RegisterSingle<IInputService>(implementation: CreateInputService());
            services.RegisterSingle<IFpsService>(implementation: new FpsService());
            services.RegisterSingle<ICoroutineRunner>(implementation: _coroutineRunner);
            services.RegisterSingle<IAssetProvider>(implementation: new AssetProvider());
            services.RegisterSingle<IProgressAccess>(implementation: new ProgressAccess());
            services.RegisterSingle<IProgressWatchers>(implementation: new ProgressWatchers(
                progressAccess: services.Resolve<IProgressAccess>()));
            
            services.RegisterSingle<IEnemyFactory>(implementation: new EnemyFactory(
                assetProvider: services.Resolve<IAssetProvider>()));
            
            services.RegisterSingle<IGameFactory>(implementation: new GameFactory(
                assetProvider: services.Resolve<IAssetProvider>(), 
                progressWatchers: services.Resolve<IProgressWatchers>()));
            
            services.RegisterSingle<IStorageService>(implementation: new PlayerPrefsStorageService(
                progressAccess: services.Resolve<IProgressAccess>(), 
                progressWatchers: services.Resolve<IProgressWatchers>()));
            
            services.RegisterSingle<IAutoSaver>(implementation: new AutoSaver(
                storageService: services.Resolve<IStorageService>(), 
                coroutineRunner: services.Resolve<ICoroutineRunner>()));
        }

        private static IInputService CreateInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }
    }
}