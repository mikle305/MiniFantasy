using Additional.Abstractions.States;
using Infrastructure.Services.StaticData;

namespace Infrastructure.GameStates
{
    public class StaticDataLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IStaticDataLoader _staticDataLoader;

        public StaticDataLoadingState(
            GameStateMachine stateMachine, 
            IStaticDataLoader staticDataLoader)
        {
            _stateMachine = stateMachine;
            _staticDataLoader = staticDataLoader;
        }
        
        public void Enter()
        {
            _staticDataLoader.LoadEnemies();
            _staticDataLoader.LoadLoot();
            EnterSettingsLoadingState();
        }

        public void Exit()
        {
        }

        private void EnterSettingsLoadingState() 
            => _stateMachine.Enter<SettingsLoadingState>();
    }
}