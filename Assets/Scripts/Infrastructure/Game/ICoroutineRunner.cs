using System.Collections;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Game
{
    public interface ICoroutineRunner : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}