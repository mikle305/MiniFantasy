using Infrastructure.Services;
using UniDependencyInjection.Core.Model;
using UnityEngine;

namespace Infrastructure.EntryPoint
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private IContainerBuilder _containerBuilder;
        private IContainer _container;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            _game = new Game(this);
            _container = _game.Build();
            _game.Start(_container);
        }

        private void OnDestroy()
        {
            _container?.Dispose();
        }
    }
}