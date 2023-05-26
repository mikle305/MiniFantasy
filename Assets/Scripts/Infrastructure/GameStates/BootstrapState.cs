using Additional.Abstractions.States;
using Additional.Constants;
using Infrastructure.Services;

namespace Infrastructure.GameStates
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
                onLoaded: EnterStaticDataLoadingState);
        }

        public void Exit()
        {
        }

        private void EnterStaticDataLoadingState()
            => _stateMachine.Enter<StaticDataLoadingState>();
    }
}