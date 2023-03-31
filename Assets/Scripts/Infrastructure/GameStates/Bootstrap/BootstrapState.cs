using Additional.Abstractions.States;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.Scene;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;


        public BootstrapState(
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _sceneLoader.Load(
                sceneName: SceneName.BootstrapScene, 
                onLoaded: EnterSettingsLoadingState);
        }

        public void Exit()
        {
        }

        private void EnterSettingsLoadingState() 
            => _stateMachine.Enter<SettingsLoadingState>();
    }
}