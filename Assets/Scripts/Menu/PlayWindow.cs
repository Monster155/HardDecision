using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class PlayWindow : MonoBehaviour
    {
        [SerializeField] private string _playSceneName;
        [Space]
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _continueButton;

        private void Start()
        {
            _newGameButton.onClick.AddListener(NewGameButton_OnClick);
            _continueButton.onClick.AddListener(ContinueButton_OnClick);
        }

        private void NewGameButton_OnClick()
        {
            SceneManager.LoadScene(_playSceneName);
        }
        private void ContinueButton_OnClick()
        {
            SceneManager.LoadScene(_playSceneName);
        }
    }
}