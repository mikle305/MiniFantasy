using Infrastructure.Scene;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; }

        
        public Game(ICoroutineRunner coroutineRunner)
        {
            var sceneLoader = new SceneLoader(coroutineRunner);
            StateMachine = new GameStateMachine(sceneLoader);
        }
    }
}