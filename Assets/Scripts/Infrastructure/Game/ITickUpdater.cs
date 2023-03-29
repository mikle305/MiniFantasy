using System;
using Infrastructure.Services.Fps;

namespace Infrastructure.Game
{
    public interface ITickUpdater
    {
        public void AddTickable(ITickable tickable);

        public void CleanUp();
    }
}