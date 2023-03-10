using Domain.Units.Animations;
using Domain.Units.Follow;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    [RequireComponent(typeof(Follower))]
    [RequireComponent(typeof(HitAnimOnHealth))]
    public class EnemyActor : MonoBehaviour
    {
        private HitAnimOnHealth _hitAnimOnHealth;
        private Follower _follower;
        
        private bool _isHited;

        
        private void Awake()
        {
            InitDependencies();
            InitStatesUpdaters();
        }

        private void Update()
        {
            if (_isHited)
            {
                _follower.Block();
                return;
            }
            
            _follower.Unblock();
        }

        private void InitStatesUpdaters()
        {
            _hitAnimOnHealth.Started += 
                () => _isHited = true;

            _hitAnimOnHealth.Ended +=
                () => _isHited = false;
        }

        private void InitDependencies()
        {
            _follower = GetComponent<Follower>();
            _hitAnimOnHealth = GetComponent<HitAnimOnHealth>();
        }
    }
}