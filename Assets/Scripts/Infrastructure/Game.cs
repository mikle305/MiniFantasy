using Infrastructure.Scene;
using Infrastructure.States;
using Services.AssetManagement;
using Services.GameFactory;
using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; }
        public static IInputService InputService { get; set; }

        
        public Game(ICoroutineRunner coroutineRunner)
        {
            var assetProvider = new AssetProvider();
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new GameFactory(assetProvider));
        }
    }
}