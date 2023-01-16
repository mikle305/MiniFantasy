using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 GetAxis();

        public abstract bool IsAttackInvoked();
    }
}