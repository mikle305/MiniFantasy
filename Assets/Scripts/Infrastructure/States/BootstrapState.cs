using Infrastructure.Scene;
using Services.Input;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private readonly GameStateMachine _context;
        private readonly SceneLoader _sceneLoader;
        

        public BootstrapState(GameStateMachine context, SceneLoader sceneLoader)
        {
            _context = context;
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
            _context.Enter<LevelLoadingState>();

        private static IInputService SetupInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }
    }
}