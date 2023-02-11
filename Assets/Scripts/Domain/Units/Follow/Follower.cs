using UnityEngine;

namespace Domain.Units.Follow
{
    public abstract class Follower : MonoBehaviour
    {
        protected Transform _target;

        
        private void Update()
        {
            if (_target != null)
                UpdateTarget();
        }

        protected abstract void UpdateTarget();

        public void FollowTo(Transform target) 
            => _target = target;

        public void StopFollowing() 
            => _target = null;
    }
}