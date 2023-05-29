using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.GameStates;
using Infrastructure.Services;
using Infrastructure.Services.Configurators;
using Infrastructure.Services.StaticData;
using UniDependencyInjection.Core.Extensions;
using UniDependencyInjection.Core.Model;
using UnityEngine;

namespace Infrastructure.EntryPoint
{
    public class Game : StartUp

    {
        private readonly ICoroutineRunner _coroutineRunner;
        private GameStateMachine _stateMachine;


        public Game(ICoroutineRunner coroutineRunner)
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
            containerBuilder
                .RegisterSingle<ICoroutineRunner>(_coroutineRunner)
                .RegisterSingle<ISceneLoader, SceneLoader>()
                .RegisterSingle<IFpsService, FpsService>()
                .RegisterSingle<IAssetProvider, AssetProvider>()
                .RegisterSingle<IProgressAccess, ProgressAccess>()
                .RegisterSingle<IProgressWatchers, ProgressWatchers>()
                .RegisterSingle<IEnemyFactory, EnemyFactory>()
                .RegisterSingle<IGameFactory, GameFactory>()
                .RegisterSingle<IEnemyConfigurator, EnemyConfigurator>()
                .RegisterSingle<IStorageService, PlayerPrefsStorageService>()
                .RegisterSingle<IAutoSaver, AutoSaver>()
                .RegisterSingle<IStaticDataAccess, StaticDataAccess>();
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