using Infrastructure.Scene;

namespace Infrastructure.States
{
    public class LevelLoadingState : IPayloadedState<SceneName>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        
        public LevelLoadingState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(SceneName sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void Exit()
        {
        }
    }
}