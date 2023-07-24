using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.Units.States
{
    public class CharacterStateInitializer : MonoBehaviour
    {
        [SerializeField] private HitOnDamage _hit;
        [SerializeField] private Health _health;
        [SerializeField] private CharacterAttacker _attacker;
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private Death _death;

        private IInputService _inputService;
        private UnitStateMachine _stateMachine;


        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Start()
        {
            _stateMachine = new UnitStateMachine();
            var states = new UnitState[]
            {
                new DeathState(_death),
                new HitState(_stateMachine, _hit, _health),
                new IdleState(_stateMachine, _hit, _health, _inputService),
                new MoveState(_stateMachine, _hit, _health, _inputService, _movement),
                new AttackState(_stateMachine, _hit, _health, _attacker),
            };
            
            foreach (UnitState state in states)
                _stateMachine.AddState(state);
            
            _stateMachine.Enter<IdleState>();
        }

        private void Update()
            => _stateMachine?.Tick();
    }
}