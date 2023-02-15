using UnityEngine;
using UnityEngine.AI;

namespace Domain.Units.Follow
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

        protected override void OnUpdate()
        {
            if (!_isBlocked)
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
