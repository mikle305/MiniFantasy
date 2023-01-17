using Infrastructure.States;
using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; }

        public static IInputService InputService { get; set; }
        

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}