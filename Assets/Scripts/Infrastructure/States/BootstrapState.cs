using Infrastructure.Scene;
using Services.Input;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
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
            Game.InputService = SetupInputService();
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LevelLoadingState, SceneName>(SceneName.MainScene);

        private static IInputService SetupInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }
    }
}