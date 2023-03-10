using Infrastructure.Scene;
using Infrastructure.Services;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure.Game
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            var sceneLoader = new SceneLoader(coroutineRunner: this);
            ServiceProvider services = ServiceProvider.Container;
            
            _stateMachine = new GameStateMachine(services, sceneLoader, coroutineRunner: this);
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}