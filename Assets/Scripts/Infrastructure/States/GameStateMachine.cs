﻿using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Scene;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _states;
        private IExitableState _activeState;

        
        public GameStateMachine(SceneLoader sceneLoader, ServiceProvider services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LevelLoadingState)] = new LevelLoadingState(this, sceneLoader, services.Resolve<IGameFactory>()),
            };
        }

        /// <summary>
        /// Enter state
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        /// <summary>
        /// Enter state with payload
        /// </summary>
        /// <param name="payload"></param>
        /// <typeparam name="TState"></typeparam>
        /// <typeparam name="TPayload"></typeparam>
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}