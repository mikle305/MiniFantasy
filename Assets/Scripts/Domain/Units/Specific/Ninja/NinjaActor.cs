using Domain.Units.Follow;
using Domain.Units.Stats;
using UnityEngine;

namespace Domain.Units.Specific.Ninja
{
    [RequireComponent(typeof(Follower))]
    [RequireComponent(typeof(HitAnimOnHealth))]
    public class NinjaActor : MonoBehaviour
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
            _follower.Block();
            /*if (_isHited)
            {
                _follower.Block();
                return;
            }
            
            _follower.Unblock();*/
        }

        private void InitDependencies()
        {
            _follower = GetComponent<Follower>();
            _hitAnimOnHealth = GetComponent<HitAnimOnHealth>();
        }

        private void InitStatesUpdaters()
        {
            _hitAnimOnHealth.Started += 
                () => _isHited = true;

            _hitAnimOnHealth.Ended +=
                () => _isHited = false;
        }
    }
}