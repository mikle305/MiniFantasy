using System;
using Infrastructure.Scene;

namespace Infrastructure.Services.Scene
{
    public interface ISceneLoader
    {
        public void Load(SceneName sceneName, Action onLoaded = null);
        
        public void Load(string sceneName, Action onLoaded = null);
    }
}