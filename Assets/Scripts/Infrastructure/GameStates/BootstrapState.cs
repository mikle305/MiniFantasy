using Additional.Abstractions.States;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.Scene;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;


        public BootstrapState(
            GameStateMachine stateMachine,
            ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
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