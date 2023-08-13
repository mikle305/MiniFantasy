using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IHudFactory
    {
        public Hud CreateHud(GameObject character, Camera uiCamera);
    }
}