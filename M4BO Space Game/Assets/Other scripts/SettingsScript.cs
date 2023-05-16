using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;

public class SettingsScript : MonoBehaviour
{
    public GameObject fov;
    public GameObject sensitivity;
    public GameObject gameAudio;
    internal SettingsClass fovSlider;

    void Start()
    {
        fovSlider = fov.AddComponent<SettingsClass>();
        fovSlider.Initialize("FOV", "Slider", fov, 40, 100);
        SettingsClass sensitivitySlider = sensitivity.AddComponent<SettingsClass>();
        sensitivitySlider.Initialize("Sensitivity", "Slider", sensitivity, 1, 10);
    }
    
    void Update()
    {
        GameManagement.fov = fovSlider.sliderData;
        Debug.Log(GameManagement.fov);
    }
}
