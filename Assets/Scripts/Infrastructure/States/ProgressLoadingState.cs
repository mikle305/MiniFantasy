using Data;
using Infrastructure.Scene;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.States
{
    public class ProgressLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IStorageService _storageService;


        public ProgressLoadingState(
            GameStateMachine stateMachine, 
            IPersistentProgressService progressService, 
            IStorageService storageService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _storageService = storageService;
        }

        public void Enter()
        {
            LoadOrInitProgress(_progressService);
            string sceneName = _progressService.PlayerProgress.WorldData.LevelPosition.Level;
            _stateMachine.Enter<LevelLoadingState, string>(sceneName);
        }

        public void Exit()
        {
        }

        private void LoadOrInitProgress(IPersistentProgressService progressService)
        {
            progressService.PlayerProgress = _storageService.LoadProgress() ?? CreateNewProgress();
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