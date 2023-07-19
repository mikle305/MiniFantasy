using UnityEngine;

namespace GamePlay.Units.States
{
    public abstract class UnitState : MonoBehaviour
    {
        public abstract void Enter();
        public abstract void OnUpdate();
        public abstract void Exit();
    }
}