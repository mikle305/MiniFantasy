using Additional.Extensions;
using UnityEngine;

namespace GamePlay.Units
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5;
        [SerializeField] private float _rotationSpeed = 20;
        [SerializeField] private float _minRotateAngle = 10;

        private CharacterController _characterController;
        private IMoveAnimator _characterAnimator;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAnimator = GetComponent<IMoveAnimator>();
        }

        public void Move(Vector2 axis, Vector3 cameraDirection)
        {
            Vector3 movementVector;
            if (axis.y > 0)
            {
                TryRotate(cameraDirection);
                movementVector = transform.forward * _movementSpeed;
                _characterAnimator.UpdateMoving(1);
            }
            else
            {
                movementVector = Vector3.zero;
                _characterAnimator.StopMoving();
            }
            
            movementVector += Physics.gravity;
            _characterController.Move(movementVector * Time.deltaTime);
        }

        private void TryRotate(Vector3 cameraDirection)
        {
            float rotationAngle = CalculateRotationAngle(cameraDirection);
            if (Mathf.Abs(rotationAngle) <= _minRotateAngle)
                return;
            
            transform.Rotate(Vector3.up * (rotationAngle * _rotationSpeed * Time.deltaTime));
        }

        private float CalculateRotationAngle(Vector3 cameraDirection)
        {
            float desiredRotationAngle = Vector3.Angle(transform.forward, cameraDirection);
            if (Vector3.Cross(transform.forward, cameraDirection).y < 0)
                desiredRotationAngle *= -1;
            
            return desiredRotationAngle;
        }

        public void Warp(Vector3 to)
        {
            _characterController.enabled = false;
            transform.position = to.AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
