using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Units.Death
{
    public class DestroyOnDeath : MonoBehaviour
    {
        private float _destroyDuration;

        public event Action Destroyed;
        

        public void Init(float destroyDuration)
        {
            _destroyDuration = destroyDuration;
            GetComponent<Death>().Happened += Destroy;
        }

        private void Destroy() 
            => StartCoroutine(DestroyCoroutine());

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(_destroyDuration);
            
            Destroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}