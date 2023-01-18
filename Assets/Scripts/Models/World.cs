using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Transform SpawnPoint => _spawnPoint;
}
