using UnityEngine;

namespace GamePlay.Additional
{
    public class MovementVectorBuilder
    {
        private Vector3 _movementVector;

        
        public MovementVectorBuilder()
        {
            _movementVector = Vector3.zero;
        }

        public void WithAxis(Vector2 axis)
        {
            _movementVector.x = axis.x;
            _movementVector.z = axis.y;
        }
        
        public void TransformToWorld(Transform transform)
            => _movementVector = transform.TransformDirection(_movementVector);
        
        public void Normalize()
            => _movementVector.Normalize();

        public void WithGravity()
            => _movementVector += Physics.gravity;

        public Vector3 Build()
            => _movementVector;
    }
}