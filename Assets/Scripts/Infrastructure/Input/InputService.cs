using UnityEngine;

namespace Infrastructure.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Fire = "Fire";
        
        public abstract Vector2 GetAxis();

        public abstract bool IsAttackInvoked();
    }
}