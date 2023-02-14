using System.Collections;
using Domain.Units.Follow;
using UnityEngine;

namespace Domain.Reaction
{
    public class AggroZone : ReactionZone
    {
        [SerializeField] private Follower _follower;
        
        [Header("Settings")] [Space(3)]
        [Tooltip("In seconds")] [SerializeField] private float _followingCooldown;

        private Coroutine _aggroCooldown;
        private bool _hasAggroTarget;


        protected override void OnTriggerEntered(Collider entered)
        {
            if (_hasAggroTarget)
                return;

            _hasAggroTarget = true;
            BreakAggroCooldown();
            StartFollowing(entered.transform);
        }

        protected override void OnTriggerExited(Collider entered)
        {
            if (!_hasAggroTarget)
                return;

            _hasAggroTarget = false;
            _aggroCooldown = StartCoroutine(StopFollowingWithDelay());
        }

        private void StartFollowing(Transform target) 
            => _follower.FollowTo(target);

        private IEnumerator StopFollowingWithDelay()
        {
            yield return new WaitForSeconds(_followingCooldown);

            _follower.StopFollowing();
        }

        private void BreakAggroCooldown()
        {
            if (_aggroCooldown == null)
                return;
            
            StopCoroutine(_aggroCooldown);
        }
    }
}