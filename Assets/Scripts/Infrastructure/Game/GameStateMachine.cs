using System;
using System.Collections.Generic;
using Additional.Abstractions.States;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AutoSaver;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Fps;
using Infrastructure.Services.Progress;
using Infrastructure.Services.Storage;
using Infrastructure.States;
using Unity.VisualScripting;
using IState = Additional.Abstractions.States.IState;

namespace Infrastructure.Game
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _map;
        private IExitableState _currentState;

        
        public GameStateMachine(ServiceProvider services,
            SceneLoader sceneLoader,
            ICoroutineRunner coroutineRunner, 
            ITickUpdater tickUpdater)
        {
            _map = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                    stateMachine: this, 
                    services: services, 
                    sceneLoader: sceneLoader, 
                    coroutineRunner: coroutineRunner,
                    tickUpdater: tickUpdater),
                [typeof(SettingsLoadingState)] = new SettingsLoadingState(
                    stateMachine: this,
                    fpsService: services.Resolve<IFpsService>()),
                [typeof(ProgressLoadingState)] = new ProgressLoadingState(
                    stateMachine: this, 
                    progressAccess: services.Resolve<IProgressAccess>(), 
                    storageService: services.Resolve<IStorageService>(),
                    autoSaver: services.Resolve<IAutoSaver>()),
                [typeof(LevelLoadingState)] = new LevelLoadingState(
                    stateMachine: this, 
                    sceneLoader: sceneLoader, 
                    gameFactory: services.Resolve<IGameFactory>(),
                    progressWatchers: services.Resolve<IProgressWatchers>()),
                [typeof(GamePlayState)] = new GamePlayState(
                    stateMachine: this, 
                    autoSaver: services.Resolve<IAutoSaver>()),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            
            var state = GetState<TState>();
            _currentState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState 
            => _map[typeof(TState)] as TState;
    }
}