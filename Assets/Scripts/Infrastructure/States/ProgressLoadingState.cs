using Additional.Constants;
using Data;
using Infrastructure.Scene;
using Infrastructure.Services.AutoSaver;
using Infrastructure.Services.Progress;
using Infrastructure.Services.Storage;

namespace Infrastructure.States
{
    public class ProgressLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressAccess _progressAccess;
        private readonly IStorageService _storageService;
        private readonly IAutoSaver _autoSaver;


        public ProgressLoadingState(
            GameStateMachine stateMachine,
            IProgressAccess progressAccess,
            IStorageService storageService, 
            IAutoSaver autoSaver)
        {
            _stateMachine = stateMachine;
            _progressAccess = progressAccess;
            _storageService = storageService;
            _autoSaver = autoSaver;
        }

        public void Enter()
        {
            _progressAccess.PlayerProgress = _storageService.LoadProgress() ?? CreateNewProgress();
            _autoSaver.Start();
            
            string sceneName = _progressAccess.PlayerProgress.WorldData.LevelPosition.Level;
            _stateMachine.Enter<LevelLoadingState, string>(sceneName);
        }

        public void Exit()
        {
        }

        private static PlayerProgress CreateNewProgress()
        {
            return new PlayerProgress
            {
                WorldData = CreateNewWorldData(),
                CharacterStats = CreateNewCharacterStats()
            };
        }

        private static WorldData CreateNewWorldData()
        {
            var mainScene = SceneName.MainScene.ToString();
            
            return new WorldData
            {
                LevelPosition = new LevelPosition
                {
                    Level = mainScene
                }
            };
        }

        private static CharacterStatsData CreateNewCharacterStats()
        {
            return new CharacterStatsData
            {
                Health = new StatData
                {
                    MaxValue = CharacterStatsConst.BaseHealth,
                    CurrentValue = CharacterStatsConst.BaseHealth
                }
            };
        }
    }
}