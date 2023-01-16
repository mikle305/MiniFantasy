using Services.Input;
using UnityEngine;

public class Game
{
    public static IInputService InputService { get; private set; }

    public Game()
    {
        RegisterInput();
    }

    private static void RegisterInput()
    {
        if (Application.isMobilePlatform)
            InputService = new MobileInputService();
        else
            InputService = new StandaloneInputService();
    }
}