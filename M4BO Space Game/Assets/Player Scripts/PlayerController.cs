using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    private float sensitivity = GameManagement.sensitivity;
    private Rigidbody rb;
    private GameObject playerCamera;
    private Vector2 rotationCam = Vector2.zero;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("PlayerCamera");
    }

    void Update()
    {
        float camInputX = Input.GetAxis("Mouse X");
        float camInputY = Input.GetAxis("Mouse Y");
        rotationCam += new Vector2(-camInputY, camInputX);
        playerCamera.transform.eulerAngles = rotationCam * sensitivity;
        transform.Rotate(0, camInputX * sensitivity, 0);
        if (Input.GetAxis("Vertical") != 0)
        {
            rb.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        }
    }
}
