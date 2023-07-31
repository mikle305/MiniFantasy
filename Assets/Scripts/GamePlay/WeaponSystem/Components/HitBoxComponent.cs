using StaticData;

namespace GamePlay.WeaponSystem
{
    public class HitBoxComponent : WeaponComponent<HitBoxComponentData>
    {
        public HitBoxComponent()
        {
            float test = _data.Distance;
        }
    }
}