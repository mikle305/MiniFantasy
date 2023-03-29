using Additional.Attributes;
using UnityEngine;

namespace Domain.Units.Spawn
{
    public class UniqueId : MonoBehaviour
    {
        [InspectorReadOnly] [SerializeField] private string _id;

        public string Id
        {
            get => _id;
            set => _id = value;
        }
    }
}