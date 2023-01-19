using Data;
using Infrastructure.Scene;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Storage;

namespace Infrastructure.States
{
    public class ProgressLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressAccess _progressAccess;
        private readonly IStorageService _storageService;


        public ProgressLoadingState(
            GameStateMachine stateMachine, 
            IPersistentProgressAccess progressAccess, 
            IStorageService storageService)
        {
            _stateMachine = stateMachine;
            _progressAccess = progressAccess;
            _storageService = storageService;
        }

        public void Enter()
        {
            _progressAccess.PlayerProgress = _storageService.LoadProgress() ?? CreateNewProgress();
            
            string sceneName = _progressAccess.PlayerProgress.WorldData.LevelPosition.Level;
            _stateMachine.Enter<LevelLoadingState, string>(sceneName);
        }

        public void Exit()
        {
        }

        private static PlayerProgress CreateNewProgress()
        {
            var mainScene = SceneName.MainScene.ToString();
            
            return new PlayerProgress
            {
                WorldData = new WorldData
                {
                    LevelPosition = new LevelPosition
                    {
                        Level = mainScene
                    }
                }
            };
        }
    }
}