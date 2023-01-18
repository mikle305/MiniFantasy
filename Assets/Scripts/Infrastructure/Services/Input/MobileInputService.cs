using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class MobileInputService: InputService
    {
        public override Vector2 GetAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        public override bool IsAttackInvoked() => 
            SimpleInput.GetButtonUp(Fire);
    }
}