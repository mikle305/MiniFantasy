using System.Collections.Generic;
using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.Services.Fps;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure.Game
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner, ITickUpdater
    {
        private GameStateMachine _stateMachine;

        private readonly List<ITickable> _tickableServices = new();


        private void Awake()
        {
            var sceneLoader = new SceneLoader(coroutineRunner: this);
            ServiceProvider services = ServiceProvider.Container;
            
            _stateMachine = new GameStateMachine(
                services, 
                sceneLoader, 
                coroutineRunner: this,
                tickUpdater: this);
            
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            for (var i = 0; i < _tickableServices.Count; i++) 
                _tickableServices[i].OnTick();
        }

        public void AddTickable(ITickable tickable) 
            => _tickableServices.Add(tickable);

        public void CleanUp() 
            => _tickableServices.Clear();
    }
}