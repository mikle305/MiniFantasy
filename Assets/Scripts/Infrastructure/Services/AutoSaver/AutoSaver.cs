using System.Collections;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AutoSaver : IAutoSaver
    {
        private const float _saveTime = 1.0f;
        private Coroutine _saveLoopCoroutine;

        private readonly IStorageService _storageService;
        private readonly ICoroutineRunner _coroutineRunner;


        public AutoSaver(IStorageService storageService, ICoroutineRunner coroutineRunner)
        {
            _storageService = storageService;
            _coroutineRunner = coroutineRunner;
        }

        public void Start() => 
            _saveLoopCoroutine = _coroutineRunner.StartCoroutine(SaveLoop());

        public void Stop()
        {
            if (_saveLoopCoroutine != null)
                _coroutineRunner.StopCoroutine(_saveLoopCoroutine);
        }

        private IEnumerator SaveLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(_saveTime);
                
                _storageService.SaveProgress();
            }
        }
    }
}