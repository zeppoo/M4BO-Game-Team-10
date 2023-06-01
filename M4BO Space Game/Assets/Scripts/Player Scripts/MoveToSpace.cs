using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToSpace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "SpaceShip")
        {
            SceneManager.LoadScene("SpaceGrounds");
        }
    }
}
