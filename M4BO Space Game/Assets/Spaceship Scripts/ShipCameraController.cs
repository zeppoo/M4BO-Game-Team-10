using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCameraController : MonoBehaviour
{
    public GameObject playerCamera;
    Rigidbody rb;
    public float rotationSpeed = 2;
    public float movementSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 camInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(-camInput.y * rotationSpeed, camInput.x * rotationSpeed, 0);

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * movementSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.MovePosition(transform.position + -transform.forward * Time.deltaTime * movementSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
        /*
        if (Input.GetAxis("Horizontal"))
        {
            
        }*/
    }
}
