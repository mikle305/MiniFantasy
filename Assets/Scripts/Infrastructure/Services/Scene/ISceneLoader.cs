using System;
using Additional.Constants;

namespace Infrastructure.Services
{
    public interface ISceneLoader
    {
        public void Load(SceneName sceneName, Action onLoaded = null);
        
        public void Load(string sceneName, Action onLoaded = null);
    }
}