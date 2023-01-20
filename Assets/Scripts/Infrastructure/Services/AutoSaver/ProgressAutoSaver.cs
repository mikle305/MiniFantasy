using System.Collections;
using Infrastructure.Game;
using Infrastructure.Services.Storage;
using UnityEngine;

namespace Infrastructure.Services.AutoSaver
{
    public class ProgressAutoSaver : IProgressAutoSaver
    {
        private bool _isActive;
        private readonly float _saveTime;

        private readonly IStorageService _storageService;
        private readonly ICoroutineRunner _coroutineRunner;


        public ProgressAutoSaver(IStorageService storageService, ICoroutineRunner coroutineRunner)
        {
            _storageService = storageService;
            _coroutineRunner = coroutineRunner;
            _saveTime = 1.0f;
        }

        public void Start()
        {
            _isActive = true;
            _coroutineRunner.StartCoroutine(Save());
        }

        public void Stop() => 
            _isActive = false;

        private IEnumerator Save()
        {
            while (true)
            {
                if (!_isActive)
                    yield break;

                yield return new WaitForSeconds(_saveTime);
                
                _storageService.SaveProgress();
            }
        }
    }
}