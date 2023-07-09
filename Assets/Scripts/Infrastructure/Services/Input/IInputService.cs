using UnityEngine;

namespace Infrastructure.Services
{
    public interface IInputService
    {
        public Vector2 GetAxis();

        public bool IsAttackInvoked();
        
        public bool IsUiPressed();
        Vector3 GetCameraDirection();
    }
}