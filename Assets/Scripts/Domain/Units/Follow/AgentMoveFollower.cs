using UnityEngine.AI;

namespace Domain.Units.Follow
{
    public class AgentMoveFollower : Follower
    {
        private NavMeshAgent _agent;


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        protected override void UpdateTarget()
        {
            _agent.destination = _target.position;
        }
    }
}
