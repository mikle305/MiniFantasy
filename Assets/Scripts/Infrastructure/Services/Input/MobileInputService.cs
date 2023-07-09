using UnityEngine;

namespace Infrastructure.Services
{
    public class MobileInputService: InputService
    {
        public MobileInputService(IObjectsProvider objectsProvider) : base(objectsProvider)
        {
        }

        public override Vector2 GetAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        public override bool IsAttackInvoked() => 
            SimpleInput.GetButtonUp(Fire);

        public override bool IsUiPressed()
            => false;
    }
}