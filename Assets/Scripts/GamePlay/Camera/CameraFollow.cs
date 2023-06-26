using UnityEngine;

namespace GamePlay.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private int _distance;
        [SerializeField] private float _offsetY;

        private Transform _target;

        
        public void Follow(Transform target) =>
            _target = target;
        
        private void LateUpdate()
        {
            if(_target == null)
                return;
            
            transform.rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            transform.position = transform.rotation * new Vector3(0, 0, -_distance) + GetFollowingPointPosition();
        }
        
        private Vector3 GetFollowingPointPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}
