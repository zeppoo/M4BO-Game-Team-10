using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToPlanet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        SceneManager.LoadScene(other.gameObject.name);
    }
}
