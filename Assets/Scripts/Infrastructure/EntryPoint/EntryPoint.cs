using Infrastructure.Services;
using UniDependencyInjection.Core;
using UnityEngine;

namespace Infrastructure.EntryPoint
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private StartUp _startUp;
        private IContainerBuilder _containerBuilder;
        private IContainer _container;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            _startUp = new StartUp(this);
            _container = _startUp.Build();
            _startUp.Start(_container);
        }

        private void OnDestroy()
        {
            _container?.Dispose();
        }
    }
}