using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // holds lock values to manage the Windows cursor
    CursorLockMode lockMode;
    
    public void Click()
    {
        SceneManager.LoadScene("SpaceGrounds");
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }
}
