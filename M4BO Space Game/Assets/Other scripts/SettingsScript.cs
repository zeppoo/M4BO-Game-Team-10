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
    private List<SettingsClass> SettingsList = new List<SettingsClass>();
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;

            if (obj.name == "Image" || obj.name == "Title") { continue; }

            string type = obj.transform.Find("type").GetComponent<TextMeshProUGUI>().text;

            SettingsClass setting = obj.AddComponent<SettingsClass>();
            setting.__init__(obj.name, type, obj);

            SettingsList.Add(setting);
        }
    }

    private void Update()
    {
        foreach (var setting in SettingsList)
        {
            setting.Activate();
        }
    }
}
