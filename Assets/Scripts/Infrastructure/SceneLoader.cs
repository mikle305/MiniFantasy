using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadingCoroutine(name, onLoaded));

        private IEnumerator LoadingCoroutine(string name, Action onLoaded = null)
        {
            AsyncOperation nextSceneWaiter = SceneManager.LoadSceneAsync(name);

            while (!nextSceneWaiter.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}