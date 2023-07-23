using UnityEngine;

namespace GamePlay.Units.States
{
    public abstract class UnitState
    {
        public virtual void Enter() {}
        public virtual void Tick() {}
        public virtual void Exit() {}
    }
}