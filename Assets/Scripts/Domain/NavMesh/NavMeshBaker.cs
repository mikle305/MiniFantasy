using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshBaker : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;

    
    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    public void Bake() =>
        _navMeshSurface.BuildNavMesh();
}
