using Infrastructure.GameStates;
using Infrastructure.Services;
using UniDependencyInjection.Core.Extensions;
using UniDependencyInjection.Core.Model;
using UnityEngine;

namespace Infrastructure.EntryPoint
{
    public class StartUp : DiContainer.UniDependencyInjection.Core.Unity.StartUp

    {
        private readonly ICoroutineRunner _coroutineRunner;
        private GameStateMachine _stateMachine;


        public StartUp(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        protected override void ConfigureServices(IContainerBuilder containerBuilder)
        {
            RegisterDefaultServices(containerBuilder);
            RegisterPlatformDependentServices(containerBuilder);
            RegisterGameStates(containerBuilder);
        }

        private void RegisterDefaultServices(IContainerBuilder containerBuilder)
        {
            var staticDataService = new StaticDataService();

            containerBuilder
                .RegisterSingle(_coroutineRunner)
                .RegisterSingle<ISceneLoader, SceneLoader>()
                .RegisterSingle<IAssetProvider, AssetProvider>()
                .RegisterSingle<IGameFactory, GameFactory>()
                .RegisterSingle<IEnemyFactory, EnemyFactory>()
                .RegisterSingle<ILootFactory, LootFactory>()
                .RegisterSingle<IEnemyConfigurator, EnemyConfigurator>()
                .RegisterSingle<ILootConfigurator, LootConfigurator>()
                .RegisterSingle<IProgressAccess, ProgressAccess>()
                .RegisterSingle<IProgressWatchers, ProgressWatchers>()
                .RegisterSingle<IStorageService, PlayerPrefsStorageService>()
                .RegisterSingle<IAutoSaver, AutoSaver>()
                .RegisterSingle<IStaticDataAccess>(staticDataService)
                .RegisterSingle<IStaticDataLoader>(staticDataService)
                .RegisterSingle<IRandomizer, Randomizer>()
                .RegisterSingle<IFpsService, FpsService>();
        }

        private static void RegisterPlatformDependentServices(IContainerBuilder containerBuilder)
        {
            if (Application.isMobilePlatform)
            {
                containerBuilder.RegisterSingle<IInputService, MobileInputService>();
            }
            else
            {
                containerBuilder.RegisterSingle<IInputService, StandaloneInputService>();
            }
        }

        private static void RegisterGameStates(IContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterSingle<GameStateMachine>()
                .RegisterSingle<BootstrapState>()
                .RegisterSingle<StaticDataLoadingState>()
                .RegisterSingle<SettingsLoadingState>()
                .RegisterSingle<ProgressLoadingState>()
                .RegisterSingle<LevelLoadingState>()
                .RegisterSingle<GameProcessState>();
        }

        public void Start(IContainer container)
        {
            _stateMachine = container.CreateScope().Resolve<GameStateMachine>();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}