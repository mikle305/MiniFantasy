using System;
using Additional.Constants;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Services
{
    public class StandaloneInputService : InputService
    {
        public StandaloneInputService(IObjectsProvider objectsProvider) : base(objectsProvider)
        {
            // Cursor.lockState = CursorLockMode.Locked;
        }
        
        public override Vector2 GetAxis() =>
            new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        public override bool IsAttackInvoked() => 
            Math.Abs(Input.GetAxis(Fire) - 1.0f) < Constants.Epsilon;
        
        public override bool IsUiPressed() =>
            Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject();
    }
}