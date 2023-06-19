using UnityEngine;

namespace Domain.Units.Follow
{
    public abstract class Follower : MonoBehaviour
    {
        protected Transform _target;


        public void FollowTo(Transform target) 
            => _target = target;

        public void StopFollowing() 
            => _target = null;

        public abstract void Block();

        public abstract void Unblock();
    }
}