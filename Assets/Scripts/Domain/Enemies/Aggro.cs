using System.Collections;
using Domain.Follow;
using UnityEngine;

namespace Domain.Enemies
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver; 
        [SerializeField] private Follower _follower;
        
        [Header("Settings")] [Space(3)] 
        [Tooltip("In seconds")] [SerializeField] private float _followingCooldown;

        private Coroutine _aggroCooldown;
        private bool _hasAggroTarget;


        private void Start()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;
        }

        private void OnTriggerEntered(Collider entered)
        {
            if (_hasAggroTarget)
                return;

            _hasAggroTarget = true;
            StopAggroCooldown();
            _follower.FollowTo(entered.transform);
        }

        private void OnTriggerExited(Collider to)
        {
            if (!_hasAggroTarget)
                return;

            _hasAggroTarget = false;
            _aggroCooldown = StartCoroutine(StartAggroCooldown());
        }

        private IEnumerator StartAggroCooldown()
        {
            yield return new WaitForSeconds(_followingCooldown);

            _follower.StopFollowing();
        }

        private void StopAggroCooldown()
        {
            if (_aggroCooldown == null)
                return;
            
            StopCoroutine(_aggroCooldown);
        }
    }
}