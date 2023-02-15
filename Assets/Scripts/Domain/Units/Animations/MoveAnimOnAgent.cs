using Additional.Constants;
using Domain.Units.AnimatorAbstractions;
using UnityEngine;
using UnityEngine.AI;

namespace Domain.Units.Specific.Ninja
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(IMoveAnimator))]
    public class MoveAnimOnAgent : MonoBehaviour
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