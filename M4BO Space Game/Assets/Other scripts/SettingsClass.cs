using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsClass : MonoBehaviour
{
    internal string Name;
    internal string type;
    internal GameObject obj;
    private int min;
    private int max;
    public float sliderData;
    

    public void Initialize(string name, string type, GameObject obj, int min, int max)
    {
        this.Name = name;
        this.type = type;
        this.min = min;
        this.max = max;
        this.obj = obj;
    }

    void Start()
    {
        if (this.type == "Slider")
        {
            Sliders newSlider = new Sliders(this.min, this.max, this.obj);
        }
    }

    void Update()
    {
        sliderData = obj.GetComponent<Slider>().value;
    }
}

public class Sliders
{
    internal GameObject obj;
    public Slider slider;
    private int min;
    private int max;

    public Sliders(int min, int max, GameObject obj)
    {
        this.min = min;
        this.max = max;
        this.obj = obj;
        this.slider = obj.GetComponent<Slider>();
        this.slider.minValue = this.min;
        this.slider.maxValue = this.max;
    }
}
