using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveFollower : Follower
    {
        private NavMeshAgent _agent;
        private bool _isBlocked;


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_target == null || _isBlocked)
                return;
            
            _agent.destination = _target.position;
        }

        public override void Block()
        {
            _agent.destination = transform.position;
            _isBlocked = true;
        }
        
        public override void Unblock()
            => _isBlocked = false;
    }
}
