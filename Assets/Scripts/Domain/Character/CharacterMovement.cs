using Additional;
using Additional.Extensions;
using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Domain.Character
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class CharacterMovement : MonoBehaviour, ISavedProgressWriter
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        private Transform _world;
        
        private bool _isWorldNull = true;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void InitWorld(Transform world)
        {
            if (!_isWorldNull)
                return;
                
            _world = world;
            _isWorldNull = false;
        }

        public bool Move(Vector2 axis)
        {
            if (_isWorldNull)
                return false;

            var isMoved = false;
            Vector3 movementVector = Vector3.zero;
            
            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                isMoved = true;
                
                movementVector.x = axis.x;
                movementVector.z = axis.y;
                movementVector = _world.TransformDirection(movementVector);
                movementVector.Normalize();
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
                
            _characterController.Move(movementVector * (_speed * Time.deltaTime));

            return isMoved;
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.ToUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }

        private static string GetCurrentLevel() =>
            SceneManager.GetActiveScene().name;

        public void LoadProgress(PlayerProgress progress)
        {
            LevelPosition levelPosition = progress.WorldData.LevelPosition;
            if (levelPosition.Level != GetCurrentLevel())
                return;

            Vector3Data savedPosition = levelPosition.Position;
            if (savedPosition == null)
                return;
            
            Warp(to: savedPosition);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.LevelPosition = new LevelPosition
            {
                Level = GetCurrentLevel(),
                Position = transform.position.ToVectorData()
            };
        }
    }
}
