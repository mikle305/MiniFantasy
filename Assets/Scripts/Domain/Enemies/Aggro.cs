using Domain.NavMesh;
using UnityEngine;

namespace Domain.Enemies
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentFollow _agentFollow;

        
        private void Start()
        {
            _triggerObserver.TriggerEntered += StartAggro;
            _triggerObserver.TriggerExited += StopAggro;
        }

        private void StartAggro(Collider col) => 
            _agentFollow.Follow(col.transform);

        private void StopAggro(Collider col) => 
            _agentFollow.StopFollowing();
    }
}