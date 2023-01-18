using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Input;
using Infrastructure.Scene;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private static ServiceProvider _services;


        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceProvider services)
        {
            _services = services;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            
            RegisterServices(services);
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneName.BootstrapScene, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private static void RegisterServices(ServiceProvider services)
        {
            IAssetProvider assetProvider = new AssetProvider();
            IGameFactory gameFactory = new GameFactory(assetProvider);
            IInputService inputService = CreateInputService();
            
            services.RegisterSingle<IInputService>(inputService);
            services.RegisterSingle<IAssetProvider>(implementation: assetProvider);
            services.RegisterSingle<IGameFactory>(implementation: gameFactory);
        }

        private static IInputService CreateInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LevelLoadingState, SceneName>(SceneName.MainScene);
    }
}