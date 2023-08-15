using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject _playWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _exitWindow;
    [Space]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PlayButton_OnClick);
        _settingButton.onClick.AddListener(SettingButton_OnClick);
        _exitButton.onClick.AddListener(ExitButton_OnClick);

        _playWindow.SetActive(false);
        _settingsWindow.SetActive(false);
        _exitWindow.SetActive(false);
    }

    private void PlayButton_OnClick()
    {
        _playWindow.SetActive(true);
    }
    private void SettingButton_OnClick()
    {
        _settingsWindow.SetActive(true);
    }
    private void ExitButton_OnClick()
    {
        _exitWindow.SetActive(true);
    }
}