using Cinemachine;
using UnityEngine;

namespace GamePlay.Additional
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCameraBase _followVirtualCamera;


        public void Follow(Transform target)
        {
            _followVirtualCamera.Follow = target;
            _followVirtualCamera.LookAt = target;
        }
    }
}
