using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure.Game
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;

        
        public Game(ICoroutineRunner coroutineRunner)
        {
            var sceneLoader = new SceneLoader(coroutineRunner);
            ServiceProvider services = ServiceProvider.Container;
            _stateMachine = new GameStateMachine(services, sceneLoader, coroutineRunner);
            _stateMachine.Enter<BootstrapState>();
        }
    }
}