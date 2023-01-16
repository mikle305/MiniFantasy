using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        public Vector2 GetAxis();

        public bool IsAttackInvoked();
    }
}