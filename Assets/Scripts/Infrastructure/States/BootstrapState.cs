using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
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


        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceProvider services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            
            RegisterServices(services);
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneName.BootstrapScene, EnterProgressLoadingState);
        }

        public void Exit()
        {
        }

        private static void RegisterServices(ServiceProvider services)
        {
            IInputService inputService = CreateInputService();
            var assetProvider = new AssetProvider();
            var progressAccess = new PersistentProgressAccess();
            var progressWatchers = new ProgressWatchers(progressAccess);
            var gameFactory = new GameFactory(assetProvider, progressWatchers);
            var storageService = new PlayerPrefsStorageService(progressAccess, progressWatchers);

            services.RegisterSingle<IInputService>(implementation: inputService);
            services.RegisterSingle<IAssetProvider>(implementation: assetProvider);
            services.RegisterSingle<IProgressWatchers>(implementation: progressWatchers);
            services.RegisterSingle<IGameFactory>(implementation: gameFactory);
            services.RegisterSingle<IPersistentProgressAccess>(implementation: progressAccess);
            services.RegisterSingle<IStorageService>(implementation: storageService);
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