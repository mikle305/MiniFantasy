using UnityEngine;
using UnityEngine.AI;

namespace Domain.NavMesh
{
    public class AgentFollow : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _target;


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Follow(Transform target) 
            => _target = target;

        public void StopFollowing() 
            => _target = null;

        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (_target != null)
                _agent.destination = _target.position;
        }
    }
}
