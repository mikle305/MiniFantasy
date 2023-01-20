using System;
using System.Collections;
using Infrastructure.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Scene
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(SceneName sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadingCoroutine(sceneName.ToString(), onLoaded));
        
        public void Load(string sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadingCoroutine(sceneName, onLoaded));

        private static IEnumerator LoadingCoroutine(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation nextSceneWaiter = SceneManager.LoadSceneAsync(nextScene);

            while (!nextSceneWaiter.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}