using Infrastructure.Scene;

namespace Infrastructure.States
{
    public class LevelLoadingState : IState
    {
        private readonly GameStateMachine _context;
        private readonly SceneLoader _sceneLoader;

        
        public LevelLoadingState(GameStateMachine context, SceneLoader sceneLoader)
        {
            _context = context;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneName.MainScene);
        }

        public void Exit()
        {
        }
    }
}