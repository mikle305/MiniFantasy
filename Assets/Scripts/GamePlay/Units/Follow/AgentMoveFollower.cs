using Additional.Constants;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Units
{
    public class AgentMoveFollower : Follower
    {
        [SerializeField] private NavMeshAgent _agent;
        
        private IMoveAnimator _animator;
        private bool _isBlocked;

        
        private void Awake()
        {
            _animator = GetComponent<IMoveAnimator>();
        }

        private void Update()
        {
            UpdateTargetPosition();
            UpdateAnimation();
        }

        public override void Block()
        {
            _agent.destination = transform.position;
            _isBlocked = true;
        }

        public override void Unblock()
            => _isBlocked = false;

        private void UpdateTargetPosition()
        {
            if (_target == null || _isBlocked)
                return;

            _agent.destination = _target.position;
        }

        private void UpdateAnimation()
        {
            if (IsMoving())
                _animator.UpdateMoving(_agent.velocity.magnitude);
            else
                _animator.StopMoving();
        }

        private bool IsMoving() =>
            _agent.velocity.magnitude > Constants.MinVelocity;
    }
}
