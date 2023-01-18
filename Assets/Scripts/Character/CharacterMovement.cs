using Additional;
using Additional.Extensions;
using Data;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterAnimation))]
    public class CharacterMovement : MonoBehaviour, ISavedProgressWriter
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        private CharacterAnimation _characterAnimation;
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

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.Position = new PositionOnLevel
            {
                Level = GetCurrentLevel(),
                Position = transform.position.ToVectorData()
            };
        }

        public void LoadProgress(PlayerProgress progress)
        {
            PositionOnLevel position = progress.WorldData.Position;
            if (position.Level != GetCurrentLevel())
                return;

            Vector3Data savedPosition = position.Position;
            if (savedPosition == null)
                return;
            
            Warp(to: savedPosition);
        }

        private void Awake()
        {
            ServiceProvider services = ServiceProvider.Container;

            _inputService = services.Resolve<IInputService>();
            _characterController = GetComponent<CharacterController>();
            _characterAnimation = GetComponent<CharacterAnimation>();
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

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.ToUnityVector();
            _characterController.enabled = true;
        }

        private static string GetCurrentLevel() =>
            SceneManager.GetActiveScene().name;
    }
}
