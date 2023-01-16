using Additional;
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
        

        private void Start()
        {
            _inputService = Game.InputService;
            _camera = Camera.main.transform;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            Vector2 axis = _inputService.GetAxis();
            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                _characterAnimation.PlayWalking();
                movementVector = _camera.TransformDirection(axis.x, 0, axis.y);
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
