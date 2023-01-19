using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
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
            IAssetProvider assetProvider = new AssetProvider();
            IGameFactory gameFactory = new GameFactory(assetProvider);
            IInputService inputService = CreateInputService();
            IPersistentProgressService progressService = new PersistentProgressService();
            IStorageService storageService = new PlayerPrefsStorageService(progressService, gameFactory);

            services.RegisterSingle<IAssetProvider>(implementation: assetProvider);
            services.RegisterSingle<IGameFactory>(implementation: gameFactory);
            services.RegisterSingle<IInputService>(implementation: inputService);
            services.RegisterSingle<IPersistentProgressService>(implementation: progressService);
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