using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 cameraRot = Vector2.zero;
    public float sensitivity = GameManagement.sensitivity;
    public Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
        camera.fieldOfView = GameManagement.fov;
    }

    void Update()
    {
        cameraRot.y += Input.GetAxis("Mouse X");
		cameraRot.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)cameraRot * sensitivity;
    }
}
