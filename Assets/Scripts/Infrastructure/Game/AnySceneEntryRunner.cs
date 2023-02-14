using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Game
{
    /// <summary>
    /// Wrapper of game bootstrapper to run game from any scene in editor
    /// </summary>
    public class AnySceneEntryRunner : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;

        private void Awake()
        {
            var entryPoint = FindObjectOfType<EntryPoint>();
            if (entryPoint == null)
                Instantiate(_entryPoint);
            
            Destroy(gameObject);
        }
    }
}