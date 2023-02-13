using System;
using Additional.Constants;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 GetAxis() =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

        public override bool IsAttackInvoked() => 
            Math.Abs(UnityEngine.Input.GetAxis(Fire) - 1.0f) < Constants.Epsilon;
        
        public override bool IsUiPressed() =>
            UnityEngine.Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject();
    }
}