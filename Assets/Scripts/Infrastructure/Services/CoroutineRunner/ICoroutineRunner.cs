using System.Collections;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);

        public void StopCoroutine(Coroutine coroutine);
    }
}