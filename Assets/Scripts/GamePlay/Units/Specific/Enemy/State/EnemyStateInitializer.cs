using UnityEngine;

namespace GamePlay.Units.Enemy
{
    public class EnemyStateInitializer : MonoBehaviour
    {
        [SerializeField] private HitOnDamage _hit;
        [SerializeField] private Health _health;
        [SerializeField] private Death _death;
        [SerializeField] private Follower _follower;

        private UnitStateMachine _stateMachine;
        
        
        private void Start()
        {
            _stateMachine = new UnitStateMachine();
            var states = new UnitState[]
            {
                new DeathState(_death, _follower),
                new HitState(_stateMachine, _hit, _health, _follower),
                new IdleState(_stateMachine, _hit, _health, _follower),
            };
            
            foreach (UnitState state in states)
                _stateMachine.AddState(state);
            
            _stateMachine.Enter<IdleState>();
        }

        private void Update()
            => _stateMachine?.Tick();
    }
}