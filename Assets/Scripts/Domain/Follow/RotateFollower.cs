using UnityEngine;

namespace Domain.Follow
{
    public class RotateFollower : Follower
    {
        [SerializeField] private float _speed;


        protected override void UpdateTarget()
        {
            RotateTowardsTarget();
        }

        private void RotateTowardsTarget()
        {
            Vector3 positionToLook = CalculatePositionToLook();
            Quaternion targetRotation = CalculateTargetRotation(positionToLook);
            
            float speedFactor = _speed * Time.deltaTime;

            transform.rotation = SmoothedRotate(transform.rotation, targetRotation, speedFactor);
        }

        private Quaternion SmoothedRotate(Quaternion startRotation, Quaternion endRotation, float speedFactor) 
            => Quaternion.Lerp(startRotation, endRotation, speedFactor);

        private Vector3 CalculatePositionToLook()
        {
            Vector3 followerPosition = transform.position;
            Vector3 positionDelta = _target.position - followerPosition;
            
            return new Vector3(positionDelta.x, followerPosition.y, positionDelta.z);
        }

        private Quaternion CalculateTargetRotation(Vector3 position) 
            => Quaternion.LookRotation(position);
    }
}