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
        

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(SceneName.BootstrapScene, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private static void RegisterServices()
        {
            ServiceProvider services = ServiceProvider.Container;

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