using System.Collections;
using Domain.NavMesh;
using UnityEngine;
using UnityEngine.Serialization;

namespace Domain.Enemies
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentFollow _agentFollow;
        
        [Header("Settings")] [Space(3)] 
        [Tooltip("In seconds")] [SerializeField] private float _followingCooldown;

        private Coroutine _aggroCoroutine;


        private void Start()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;
        }

        private void OnTriggerEntered(Collider to)
        {
            StopAggroCooldown();
            
            _agentFollow.Follow(to.transform);
        }

        private void OnTriggerExited(Collider to)
        {
            _aggroCoroutine = StartCoroutine(StartAggroCooldown());
        }

        private IEnumerator StartAggroCooldown()
        {
            yield return new WaitForSeconds(_followingCooldown);
            
            _agentFollow.StopFollowing();
        }

        private void StopAggroCooldown()
        {
            if (_aggroCoroutine == null)
                return;
            
            StopCoroutine(_aggroCoroutine);
        }
    }
}