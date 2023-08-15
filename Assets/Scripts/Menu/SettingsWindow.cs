using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        private void Start()
        {
            _closeButton.onClick.AddListener(CloseButton_OnClick);
        }

        private void CloseButton_OnClick()
        {
            gameObject.SetActive(false);
        }
    }
}