using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCamera;
    public float sensetivity = 3;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(0, input.x * sensetivity, 0);

        playerCamera.transform.Rotate(-input.y * sensetivity, 0, 0);
    }
}
