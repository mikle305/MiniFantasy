using System;
using Additional;
using Additional.Constants;
using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 GetAxis() =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

        public override bool IsAttackInvoked() =>
            Math.Abs(UnityEngine.Input.GetAxis(Fire) - 1.0f) < Constants.Epsilon;
    }
}