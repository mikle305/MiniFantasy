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
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ServiceProvider _services;
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ITickUpdater _tickUpdater;


        public BootstrapState(GameStateMachine stateMachine,
            ServiceProvider services,
            SceneLoader sceneLoader,
            ICoroutineRunner coroutineRunner, 
            ITickUpdater tickUpdater)
        {
            _stateMachine = stateMachine;
            _services = services;
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
            _tickUpdater = tickUpdater;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(
                SceneName.BootstrapScene, 
                onLoaded: EnterSettingsLoadingState);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterSingletonService<IInputService>(instance: CreateInputService());
            RegisterSingletonService<IFpsService>(instance: new FpsService());
            RegisterSingletonService<ICoroutineRunner>(instance: _coroutineRunner);
            RegisterSingletonService<IAssetProvider>(instance: new AssetProvider());
            RegisterSingletonService<IProgressAccess>(instance: new ProgressAccess());
            RegisterSingletonService<IProgressWatchers>(instance: new ProgressWatchers(
                progressAccess: _services.Resolve<IProgressAccess>()));
            
            RegisterSingletonService<IEnemyFactory>(instance: new EnemyFactory(
                assetProvider: _services.Resolve<IAssetProvider>()));
            
            RegisterSingletonService<IGameFactory>(instance: new GameFactory(
                assetProvider: _services.Resolve<IAssetProvider>(), 
                progressWatchers: _services.Resolve<IProgressWatchers>()));
            
            RegisterSingletonService<IStorageService>(instance: new PlayerPrefsStorageService(
                progressAccess: _services.Resolve<IProgressAccess>(), 
                progressWatchers: _services.Resolve<IProgressWatchers>()));
            
            RegisterSingletonService<IAutoSaver>(instance: new AutoSaver(
                storageService: _services.Resolve<IStorageService>(), 
                coroutineRunner: _services.Resolve<ICoroutineRunner>()));
        }

        private void RegisterSingletonService<TService>(TService instance) 
            where TService : class, IService
        {
            RegisterTickable(instance);
            _services.RegisterSingle(instance);
        }

        private void RegisterTickable<TService>(TService instance)
        {
            if (instance is ITickable tickableService)
                _tickUpdater.AddTickable(tickableService);
        }

        private void EnterSettingsLoadingState() 
            => _stateMachine.Enter<SettingsLoadingState>();

        private static IInputService CreateInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }
    }
}