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

    internal bool boolean;

    internal double min;
    internal double max;

    private Scrollbar barUI;
    private TextMeshProUGUI textUI;
    private Button buttonUI;

    private void ChangeSetting()
    {
        Debug.Log("hallo");
    }

    public void __init__(string name, string type, GameObject obj)
    {
        this.Name = name;
        this.type = type;
        this.obj = obj;

        if (this.type.ToLower() == "slider")
        {
            this.barUI = obj.GetComponentInChildren<Scrollbar>();
            this.textUI = obj.transform.Find("Text").GetComponent<TextMeshProUGUI>();

            this.min = double.Parse(this.obj.transform.Find("min").GetComponent<TextMeshProUGUI>().text);
            this.max = double.Parse(this.obj.transform.Find("max").GetComponent<TextMeshProUGUI>().text);
        }
        else if (this.type.ToLower() == "boolean")
        {
            this.buttonUI = obj.GetComponentInChildren<Button>();

            this.buttonUI.onClick.AddListener(ChangeSetting);
        }
    }
    internal void Activate()
    {
        if (this.type == "slider")
        {
            double bar;

            if (this.barUI.value >= 0 && this.barUI.value < this.max)
            {
                bar = (this.min - (this.barUI.value * this.min)) + (this.max * this.barUI.value);
            }
            else
            {
                bar = this.max;
            }

            double showcaseValue = Math.Round(bar, 2);

            this.textUI.text = showcaseValue.ToString().Replace(",", ".");
        }
        else if (this.type == "boolean")
        {

        }
    }
}