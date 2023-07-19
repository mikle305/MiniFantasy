using UnityEngine;

namespace Infrastructure.Services
{
    public interface IInputService
    {
        public Vector2 GetAxis();
        
        public Vector3 GetCameraDirection();

        public bool IsAttackInvoked();
    }
}