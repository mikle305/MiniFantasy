using UnityEngine;

namespace Infrastructure.Services
{
    public interface IObjectsProvider
    {
        public Camera MainCamera { get; set; }
    }
}