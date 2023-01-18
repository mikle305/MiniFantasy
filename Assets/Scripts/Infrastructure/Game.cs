using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        
        public Game(ICoroutineRunner coroutineRunner)
        {
            var sceneLoader = new SceneLoader(coroutineRunner);
            _stateMachine = new GameStateMachine(sceneLoader, ServiceProvider.Container);
            _stateMachine.Enter<BootstrapState>();
        }
    }
}