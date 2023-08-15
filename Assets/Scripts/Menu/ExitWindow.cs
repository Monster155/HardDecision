using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class ExitWindow : MonoBehaviour
    {
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        private void Start()
        {
            _yesButton.onClick.AddListener(YesButton_OnClick);
            _noButton.onClick.AddListener(NoButton_OnClick);
        }

        private void YesButton_OnClick()
        {
            Application.Quit();
        }
        private void NoButton_OnClick()
        {
            gameObject.SetActive(false);
        }
    }
}