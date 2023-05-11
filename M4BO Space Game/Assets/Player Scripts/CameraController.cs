using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 cameraRot = Vector2.zero;
    public float sensetivity = 3;

    // Update is called once per frame
    void Update()
    {
        cameraRot.y += Input.GetAxis("Mouse X");
		cameraRot.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)cameraRot * sensetivity;
    }
}
