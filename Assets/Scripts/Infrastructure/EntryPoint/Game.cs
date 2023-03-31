using System;
using System.Collections.Generic;
using Additional.Abstractions.States;
using Infrastructure.Services;
using Infrastructure.Services.Scene;
using Infrastructure.States;
using UniDependencyInjection.Core.Extensions;
using UniDependencyInjection.Core.Model;
using UnityEngine;

namespace Infrastructure.EntryPoint
{
    public class Game
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly SceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;


        public Game(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public IContainerBuilder ConfigureServices(IContainerBuilder containerBuilder)
            => containerBuilder
                .RegisterSingle<ICoroutineRunner>(_coroutineRunner)
                .RegisterSingle<ISceneLoader, SceneLoader>()
                .RegisterSingle<IInputService>(CreateInputService())
                .RegisterSingle<IFpsService, FpsService>()
                .RegisterSingle<IAssetProvider, AssetProvider>()
                .RegisterSingle<IProgressAccess, ProgressAccess>()
                .RegisterSingle<IProgressWatchers, ProgressWatchers>()
                .RegisterSingle<IEnemyFactory, EnemyFactory>()
                .RegisterSingle<IGameFactory, GameFactory>()
                .RegisterSingle<IStorageService, PlayerPrefsStorageService>()
                .RegisterSingle<IAutoSaver, AutoSaver>()
                .RegisterSingle<BootstrapState>()
                .RegisterSingle<SettingsLoadingState>()
                .RegisterSingle<ProgressLoadingState>()
                .RegisterSingle<LevelLoadingState>()
                .RegisterSingle<GameProcessState>();

        public void Start(IContainer container)
        {
            Dictionary<Type, IExitableState> statesMap = CreateStatesMap(container);
            _stateMachine = new GameStateMachine(statesMap);
            _stateMachine.Enter<BootstrapState>();
        }

        private Dictionary<Type, IExitableState> CreateStatesMap(IContainer container)
        {
            IScope scope = container.CreateScope();
            var statesMap = new Dictionary<Type, IExitableState>();
            
            AddState<BootstrapState>();
            AddState<SettingsLoadingState>();
            AddState<ProgressLoadingState>();
            AddState<LevelLoadingState>();
            AddState<GameProcessState>();

            return statesMap;


            void AddState<TState>() where TState : IExitableState 
                => statesMap.Add(typeof(TState), scope.Resolve<TState>());
        }

        private static IInputService CreateInputService()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();

            return new StandaloneInputService();
        }
    }
}