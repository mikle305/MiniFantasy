using System;
using System.Collections;
using Additional;
using Additional.Extensions;
using Data;
using Infrastructure.Services;
using Infrastructure.Services.Input;
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
        
        private const float _attackDuration = 2.0f;

        private CharacterController _characterController;
        private CharacterAnimator _characterAnimator;
        private IInputService _inputService;
        private Transform _camera;
        private Transform _world;
        
        private bool _isWorldNull = true;
        private bool _isAttacking;


        public void InitWorld(Transform world)
        {
            if (!_isWorldNull)
                return;
                
            _world = world;
            _isWorldNull = false;
        }

        private void Awake()
        {
            ServiceProvider services = ServiceProvider.Container;

            _inputService = services.Resolve<IInputService>();
            _characterController = GetComponent<CharacterController>();
            _characterAnimator = GetComponent<CharacterAnimator>();
        }

        private void Start()
        {
            _characterAnimator.SetAttackDuration(_attackDuration);
        }

        private void Update()
        {
            if (_isWorldNull)
                return;
            
            Move();
        }

        private void Move()
        {
            if (_isAttacking)
                return;
            
            if (_inputService.IsAttackInvoked())
            {
                _isAttacking = true;
                _characterAnimator.PlayMeleeAttack();
                StartCoroutine(StopAttacking(_attackDuration));
                return;
            }
            
            Vector3 movementVector = Vector3.zero;
            Vector2 axis = _inputService.GetAxis();
            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                _characterAnimator.UpdateMoving(1);
                
                movementVector.x = axis.x;
                movementVector.z = axis.y;
                movementVector = _world.TransformDirection(movementVector);
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            else
            {
                _characterAnimator.StopMoving();
            }

            movementVector += Physics.gravity;
                
            _characterController.Move(movementVector * (_speed * Time.deltaTime));
        }

        private IEnumerator StopAttacking(float delay)
        {
            yield return new WaitForSeconds(delay);

            _isAttacking = false;
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.ToUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }

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

        private static string GetCurrentLevel() =>
            SceneManager.GetActiveScene().name;

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
