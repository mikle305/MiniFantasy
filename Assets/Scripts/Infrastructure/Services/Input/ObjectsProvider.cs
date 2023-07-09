using UnityEngine;

namespace Infrastructure.Services
{
    public class ObjectsProvider : IObjectsProvider
    {
        public Camera MainCamera { get; set; }
    }
}