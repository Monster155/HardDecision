using System;
using System.Collections;
using System.Collections.Generic;
using Testing;
using UnityEngine;
using UnityEngine.UI;

public class StressManager : MonoBehaviour
{
    [SerializeField] private Slider stressBar;
    [SerializeField] private float speed = 0.1f;

    private float min = 0;
    private float max = 100;

    private CameraShakeToggle _cameraShakeToggle;

    private void Start()
    {
        _cameraShakeToggle = GetComponent<CameraShakeToggle>();
        
        stressBar.minValue = min;
        stressBar.maxValue = max;

        stressBar.value = 50;
    }

    private void Update()
    {
        stressBar.value += 1 * Time.deltaTime * speed;

        if (stressBar.value >= 80)
        {
            _cameraShakeToggle.ToggleCameraSkake(true);
        }
        else
        {
            _cameraShakeToggle.ToggleCameraSkake(false);
        }

        if (stressBar.value > stressBar.maxValue)
        {
            stressBar.value = max;
        }
    }

    public void IncreaseStress(float amount)
    {
        stressBar.value += amount;
    }
    
    public void DecreaseStress(float amount)
    {
        stressBar.value -= amount;
    }
}

