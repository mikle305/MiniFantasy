using Domain.Units.Animations;
using Domain.Units.Follow;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Enemy
{
    public class EnemyState : MonoBehaviour
    {
        private HitOnDamage _hitOnDamage;
        private Follower _follower;
        private IHealth _health;

        private bool _isHited;
        private bool _isDied;


        private void Start()
        {
            InitDependencies();
            InitStatesUpdaters();
        }

        private void Update()
        {
            if (_isHited || _isDied)
                return;
            
            _follower.Unblock();
        }

        private void InitStatesUpdaters()
        {
            _hitOnDamage.Started += () =>
            {
                _follower.Block();
                _isHited = true;
            };

            _hitOnDamage.Ended += () => 
                _isHited = false;

            _health.ZeroReached += () =>
            {
                _follower.Block();
                _isDied = true;
            };
        }

        private void InitDependencies()
        {
            _follower = GetComponent<Follower>();
            _hitOnDamage = GetComponent<HitOnDamage>();
            _health = GetComponent<IHealth>();
        }
    }
}