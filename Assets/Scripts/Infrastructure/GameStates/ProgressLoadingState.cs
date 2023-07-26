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
            CharacterStaticData characterConfig = _staticDataService.GetCharacterData();
            _progressAccess.PlayerProgress = _storageService.LoadProgress() ?? CreateNewProgress(characterConfig);
            _autoSaver.Start();
            
            string sceneName = _progressAccess.PlayerProgress.WorldData.LevelPosition.Level;
            _stateMachine.Enter<LevelLoadingState, string>(sceneName);
        }

        public void Exit()
        {
        }

        private static PlayerProgress CreateNewProgress(CharacterStaticData characterConfig)
        {
            return new PlayerProgress
            {
                WorldData = CreateNewWorldData(),
                CharacterStats = CreateNewCharacterStats(characterConfig)
            };
        }

        private static WorldData CreateNewWorldData()
        {
            var mainScene = SceneName.MainScene.ToString();
            
            return new WorldData
            {
                LevelPosition = new LevelPosition
                {
                    Level = mainScene,
                }
            };
        }

        private static CharacterStatsData CreateNewCharacterStats(CharacterStaticData characterConfig)
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