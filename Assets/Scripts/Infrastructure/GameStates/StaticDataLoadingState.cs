using Additional.Abstractions.States;
using Infrastructure.Services.StaticData;

namespace Infrastructure.GameStates
{
    public class StaticDataLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IStaticDataAccess _staticDataAccess;

        public StaticDataLoadingState(
            GameStateMachine stateMachine, 
            IStaticDataAccess staticDataAccess)
        {
            _stateMachine = stateMachine;
            _staticDataAccess = staticDataAccess;
        }
        
        public void Enter()
        {
            _staticDataAccess.LoadEnemies();
            EnterSettingsLoadingState();
        }

        public void Exit()
        {
        }

        private void EnterSettingsLoadingState() 
            => _stateMachine.Enter<SettingsLoadingState>();
    }
}