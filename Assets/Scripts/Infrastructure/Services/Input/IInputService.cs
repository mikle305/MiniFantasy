using UnityEngine;

namespace Infrastructure.Services.Input
{
    public interface IInputService: IService
    {
        public Vector2 GetAxis();

        public bool IsAttackInvoked();
        
        public bool IsUiPressed();
    }
}