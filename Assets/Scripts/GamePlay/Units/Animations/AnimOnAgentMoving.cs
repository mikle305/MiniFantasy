using Additional.Constants;
using Domain.Units.Animations.Abstractions;
using UnityEngine;
using UnityEngine.AI;

namespace Domain.Units.Animations
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(IMoveAnimator))]
    public class AnimOnAgentMoving : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private IMoveAnimator _animator;
        

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<IMoveAnimator>();
        }

        private void Update()
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