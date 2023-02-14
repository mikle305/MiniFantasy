using UnityEngine;

namespace Infrastructure.Game
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            DontDestroyOnLoad(this);
        }
    }
}