using System.Collections;
using GamePlay.Units.Follow;
using UnityEngine;

namespace GamePlay.Reaction
{
    public class AggroZone : ReactionZone
    {
        [SerializeField] private Follower _follower;
        
        private float _followingCooldown;

        private Coroutine _aggroCooldown;
        private bool _hasAggroTarget;


        public void Init(float followingCooldown)
        {
            _followingCooldown = followingCooldown;
        }

        protected override void ObjectEntered(Collider entered)
        {
            if (_hasAggroTarget)
                return;

            BreakAggroCooldown();
            StartFollowing(entered.transform);
            _hasAggroTarget = true;
        }
        
        protected override void ObjectExited(Collider exited)
        {
            if (!_hasAggroTarget)
                return;

            _aggroCooldown = StartCoroutine(StopFollowingWithDelay());
            _hasAggroTarget = false;
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