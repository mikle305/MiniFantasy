using UnityEngine;

namespace Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 GetAxis()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsAttackInvoked()
        {
            throw new System.NotImplementedException();
        }
    }
}