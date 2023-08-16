using Cinemachine;
using UnityEngine;

namespace Testing
{
    public class CameraShakeToggle : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private void Start()
        {
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
        }

        public void ToggleCameraSkake(bool value)
        {
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().enabled = value;
        }
    }
}
