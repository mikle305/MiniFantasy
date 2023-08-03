using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Units.Death
{
    public class DestroyOnDeath : MonoBehaviour
    {
        [SerializeField] private Death _death;
        
        private float _destroyDuration;

        public event Action Destroyed;
        

        public void Init(float destroyDuration)
        {
            _destroyDuration = destroyDuration;
            _death.Happened += Destroy;
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