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
    public bool buttonData;
    Buttons newButton;
    Sliders newSlider;

    
    public void Initialize(string name, string type, GameObject obj, int min, int max)
    {
        this.Name = name;
        this.type = type;
        this.min = min;
        this.max = max;
        this.obj = obj;
    }

    public void Start()
    {
        if (this.type == "Slider")
        {
            newSlider = new Sliders(this.min, this.max, this.obj);
        }
        if (this.type == "Button")
        {
            newButton = new Buttons(true, this.obj);
            newButton.button.onClick.AddListener(ClickButton);
        }
    }

    void Update()
    {       
        if (this.type == "Slider")
        {
            sliderData = obj.GetComponent<Slider>().value;
            newSlider.sliderText.text = Convert.ToString(Math.Round(sliderData, 0));
        }
        if (this.type == "Button")
        {
            buttonData = newButton.status;
        }
    }

    public void ClickButton()
    {
        newButton.ButtonClicked();
        
    }
    
}

public class Sliders
{
    internal GameObject obj;
    public Slider slider;
    private int min;
    private int max;
    public TextMeshProUGUI sliderText;

    public Sliders(int min, int max, GameObject obj)
    {
        this.min = min;
        this.max = max;
        this.obj = obj;
        this.slider = obj.GetComponent<Slider>();
        this.slider.minValue = this.min;
        this.slider.maxValue = this.max;
        this.sliderText = this.obj.transform.Find("Data").GetComponent<TextMeshProUGUI>();
    }
}

public class Buttons
{
    internal GameObject obj;
    public Button button;
    public bool status;
    internal TextMeshProUGUI buttonText;

    public Buttons(bool status, GameObject obj)
    {
        this.status = status;
        this.button = obj.GetComponent<Button>();
        this.buttonText = this.button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ButtonClicked()
    {
        this.status = this.status == true? false : true;
        buttonText.text = this.status == true? buttonText.text = "On" : buttonText.text = "Off";
    }
}
