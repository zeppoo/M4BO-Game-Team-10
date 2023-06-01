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
    public TextMeshProUGUI fovData;
    internal SettingsClass fovSlider;
    internal SettingsClass audioButton;
    internal SettingsClass sensitivitySlider;
    

    public void Start()
    {
        fovSlider = fov.AddComponent<SettingsClass>();
        fovSlider.Initialize("FOV", "Slider", fov, 60, 100);
        sensitivitySlider = sensitivity.AddComponent<SettingsClass>();
        sensitivitySlider.Initialize("Sensitivity", "Slider", sensitivity, 4, 10);
        audioButton = gameAudio.AddComponent<SettingsClass>();
        audioButton.Initialize("Audio", "Button", gameAudio, 0, 1);
    }
    
    void Update()
    {
        GameManagement.fov = fovSlider.sliderData;
        GameManagement.audio = audioButton.buttonData;
        GameManagement.sensitivity = sensitivitySlider.sliderData;
        
    }
}
