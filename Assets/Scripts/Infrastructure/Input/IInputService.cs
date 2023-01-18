using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Input
{
    public interface IInputService: IService
    {
        public Vector2 GetAxis();

        public bool IsAttackInvoked();
    }
}