using System;
using System.Collections.Generic;
using Additional.Abstractions.States;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.AutoSaver;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Progress;
using Infrastructure.Services.Storage;
using Infrastructure.States;

namespace Infrastructure.Game
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _map;
        private IExitableState _currentState;

        
        public GameStateMachine(
            ServiceProvider services, 
            SceneLoader sceneLoader, 
            ICoroutineRunner coroutineRunner)
        {
            _map = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                    this, 
                    services, 
                    sceneLoader, 
                    coroutineRunner),
                [typeof(ProgressLoadingState)] = new ProgressLoadingState(
                    this, 
                    services.Resolve<IProgressAccess>(), 
                    services.Resolve<IStorageService>(),
                    services.Resolve<IAutoSaver>()),
                [typeof(LevelLoadingState)] = new LevelLoadingState(
                    this, 
                    sceneLoader, 
                    services.Resolve<IGameFactory>(),
                    services.Resolve<IProgressWatchers>()),
                [typeof(GamePlayState)] = new GamePlayState(),
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