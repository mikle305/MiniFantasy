using UnityEngine;
using UnityEngine.AI;

public class AgentFollow : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform Target { get; set; }

    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (Target != null)
            _agent.destination = Target.position;
    }
}
