using Infrastructure.Services;

namespace Infrastructure.GameStates
{
    public class StaticDataLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public StaticDataLoadingState(
            GameStateMachine stateMachine, 
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }
        
        public void Enter()
        {
            _staticDataService.LoadEnemies();
            _staticDataService.LoadLoot();
            EnterSettingsLoadingState();
        }

        public void Exit()
        {
        }

        private void EnterSettingsLoadingState() 
            => _stateMachine.Enter<SettingsLoadingState>();
    }
}