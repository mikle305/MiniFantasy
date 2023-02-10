using System.Collections;
using Domain.NavMesh;
using UnityEngine;

namespace Domain.Enemies
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentFollow _agentFollow;
        
        [Header("Settings")] [Space(3)] 
        [Tooltip("In seconds")] [SerializeField] private float _followingCooldown;

        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;


        private void Start()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;
        }

        private void OnTriggerEntered(Collider to)
        {
            if (_hasAggroTarget)
                return;

            _hasAggroTarget = true;
            StopAggroCooldown();
            Follow(to);
        }

        private void OnTriggerExited(Collider to)
        {
            if (!_hasAggroTarget)
                return;

            _hasAggroTarget = false;
            _aggroCoroutine = StartCoroutine(StartAggroCooldown());
        }

        private IEnumerator StartAggroCooldown()
        {
            yield return new WaitForSeconds(_followingCooldown);

            StopFollow();
        }

        private void StopAggroCooldown()
        {
            if (_aggroCoroutine == null)
                return;
            
            StopCoroutine(_aggroCoroutine);
        }

        private void StopFollow() 
            => _agentFollow.StopFollowing();

        private void Follow(Collider to) 
            => _agentFollow.Follow(to.transform);
    }
}