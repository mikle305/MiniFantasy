using UnityEngine;

namespace Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Fire = "Fire";
        
        private readonly IObjectsProvider _objectsProvider;


        protected InputService(IObjectsProvider objectsProvider)
        {
            _objectsProvider = objectsProvider;
        }

        public abstract Vector2 GetAxis();

        public Vector3 GetCameraDirection()
        {
            Vector3 cameraForwardDirection = _objectsProvider.MainCamera.transform.forward;
            return new Vector3(cameraForwardDirection.x, 0, cameraForwardDirection.z);
        }

        public abstract bool IsUiPressed();

        public abstract bool IsAttackInvoked();
    }
}