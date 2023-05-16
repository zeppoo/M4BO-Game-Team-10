using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartScreenScript : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject SettingsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerGrounds");
    }
    
    public void EnableSettings()
    {
        StartScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }
}
