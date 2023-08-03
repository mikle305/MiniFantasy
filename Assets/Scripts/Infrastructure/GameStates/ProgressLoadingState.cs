using Additional.Constants;
using Data;
using Infrastructure.Services;
using StaticData.Character;

namespace Infrastructure.GameStates
{
    public class ProgressLoadingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressAccess _progressAccess;
        private readonly IStorageService _storageService;
        private readonly IAutoSaver _autoSaver;
        private readonly IStaticDataService _staticDataService;


        public ProgressLoadingState(
            GameStateMachine stateMachine,
            IProgressAccess progressAccess,
            IStorageService storageService,
            IAutoSaver autoSaver,
            IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _progressAccess = progressAccess;
            _storageService = storageService;
            _autoSaver = autoSaver;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            CharacterData characterConfig = _staticDataService.GetCharacterData();
            _progressAccess.Progress = _storageService.LoadProgress() ?? CreateNewProgress(characterConfig);
            _autoSaver.Start();
            
            string sceneName = _progressAccess.Progress.Character.CurrentLevel.Name;
            _stateMachine.Enter<LevelLoadingState, string>(sceneName);
        }

        public void Exit()
        {
        }

        private static GameProgress CreateNewProgress(CharacterData characterConfig)
        {
            return new GameProgress
            { 
                Character = new CharacterProgress
                {
                    CurrentLevel = CreateNewLevelData(), 
                    Stats = CreateNewCharacterStats(characterConfig),
                } 
            };
        }

        private static LevelData CreateNewLevelData()
        {
            var mainScene = SceneName.MainScene.ToString();
            
            return new LevelData()
            {
                Name = mainScene,
            };
        }

        private static CharacterStatsData CreateNewCharacterStats(CharacterData characterConfig)
        {
            return new CharacterStatsData
            {
                Health = new StatData
                {
                    MaxValue = characterConfig.Health,
                }
            };
        }
    }
}