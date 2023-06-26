using UnityEngine;

namespace GamePlay.Units.Follow
{
    public class RotateFollower : Follower
    {
        [SerializeField] private float _speed;
        
        private bool _isBlocked;


        private void Update()
        {
            if (_target == null || _isBlocked)
                return;
            
            RotateToTarget(_target);
        }

        public override void Block()
            => _isBlocked = true;

        public override void Unblock() 
            => _isBlocked = false;

        private void RotateToTarget(Transform target)
        {
            Vector3 positionToLook = CalculatePositionToLook(target.position);
            Quaternion targetRotation = CalculateRotation(positionToLook);
            float speedFactor = _speed * Time.deltaTime;
            
            transform.rotation = SmoothedRotate(transform.rotation, targetRotation, speedFactor);
        }

        private Vector3 CalculatePositionToLook(Vector3 targetPosition)
        {
            Vector3 followerPosition = transform.position;
            Vector3 positionDelta = targetPosition - followerPosition;
            
            return new Vector3(positionDelta.x, followerPosition.y, positionDelta.z);
        }

        private static Quaternion CalculateRotation(Vector3 positionToLook) 
            => Quaternion.LookRotation(positionToLook);

        private static Quaternion SmoothedRotate(Quaternion startRotation, Quaternion endRotation, float speedFactor) 
            => Quaternion.Lerp(startRotation, endRotation, speedFactor);
    }
}