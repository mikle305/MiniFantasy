using Additional.Constants;
using Additional.Extensions;
using GamePlay.Additional;
using GamePlay.Units.Animations;
using UnityEngine;

namespace GamePlay.Units.Character
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        private IMoveAnimator _characterAnimator;
        private Transform _world;

        private bool _isWorldNull = true;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAnimator = GetComponent<IMoveAnimator>();
        }

        public void InitWorld(Transform world)
        {
            if (!_isWorldNull)
                return;
                
            _world = world;
            _isWorldNull = false;
        }

        public void Move(Vector2 axis)
        {
            if (_isWorldNull)
                return;

            var vectorBuilder = new MovementVectorBuilder();
            bool axisNotZero = axis.sqrMagnitude > Constants.Epsilon;
            
            if (axisNotZero)
            {
                _characterAnimator.UpdateMoving(_speed);
                
                vectorBuilder.WithAxis(axis);
                vectorBuilder.TransformToWorld(_world);
                vectorBuilder.Normalize();
                
                transform.forward = vectorBuilder.Build();
            }
            else
            {
                _characterAnimator.StopMoving();
            }
            
            vectorBuilder.WithGravity();

            _characterController.Move(vectorBuilder.Build() * (_speed * Time.deltaTime));
        }

        public void Warp(Vector3 to)
        {
            _characterController.enabled = false;
            transform.position = to.AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
