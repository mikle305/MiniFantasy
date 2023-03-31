using UnityEngine;

namespace Infrastructure.EntryPoint
{
    /// <summary>
    /// Wrapper of entry point to run game from any scene in editor
    /// </summary>
    public class AnySceneRunner : MonoBehaviour
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