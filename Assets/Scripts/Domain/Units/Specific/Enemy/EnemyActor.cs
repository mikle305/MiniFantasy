using Domain.Units.Animations;
using Domain.Units.Follow;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    [RequireComponent(typeof(Follower))]
    [RequireComponent(typeof(AnimOnDamage))]
    public class EnemyActor : MonoBehaviour
    {
        private AnimOnDamage _animOnDamage;
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
            _animOnDamage.Started += 
                () => _isHited = true;

            _animOnDamage.Ended +=
                () => _isHited = false;
        }

        private void InitDependencies()
        {
            _follower = GetComponent<Follower>();
            _animOnDamage = GetComponent<AnimOnDamage>();
        }
    }
}