using UnityEngine;

namespace Domain.Units.Follow
{
    public abstract class Follower : MonoBehaviour
    {
        protected Transform _target;

        
        private void Update()
        {
            if (_target != null)
                OnUpdate();
        }

        public void FollowTo(Transform target) 
            => _target = target;

        public void StopFollowing() 
            => _target = null;

        protected abstract void OnUpdate();

        public abstract void Block();

        public abstract void Unblock();
    }
}