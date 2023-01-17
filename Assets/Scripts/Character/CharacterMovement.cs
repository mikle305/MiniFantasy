using Additional;
using Infrastructure;
using Services.Input;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Transform _camera;
        private Transform _world;
        private bool _isWorldNull = true;


        public void InitWorld(Transform world)
        {
            if (!_isWorldNull)
                return;
                
            _world = world;
            _isWorldNull = false;
        }

        private void Start()
        {
            _inputService = Game.InputService;
        }

        private void Update()
        {
            if (_isWorldNull)
                return;

            Move();
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;
            Vector2 axis = _inputService.GetAxis();
            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                _characterAnimation.PlayWalking();
                movementVector.x = axis.x;
                movementVector.z = axis.y;
                movementVector = _world.TransformDirection(movementVector);
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            else
            {
                _characterAnimation.PlayIdle();
            }

            movementVector += Physics.gravity;
                
            _characterController.Move(movementVector * (_speed * Time.deltaTime));
        }
    }
}
