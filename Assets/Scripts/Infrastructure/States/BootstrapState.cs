using Services.Input;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IGameState
    {
        private readonly GameStateMachine _context;

        public BootstrapState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
        }

        private static void RegisterServices()
        {
            Game.InputService = SetupInputService();
        }
        
        private static IInputService SetupInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            return new StandaloneInputService();
        }
    }
}