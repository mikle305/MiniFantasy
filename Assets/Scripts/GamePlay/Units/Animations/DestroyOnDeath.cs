using System;
using System.Collections;
using UnityEngine;

namespace Domain.Units.Animations
{
    public class DestroyOnDeath : MonoBehaviour
    {
        private float _destroyDuration;

        public event Action Destroyed;
        

        public void Init(float destroyDuration)
        {
            _destroyDuration = destroyDuration;
            GetComponent<DeathOnDamage>().Happened += Destroy;
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